using SharpOSC;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OSCManager : MonoBehaviour
{
    public Action OnLoadingIpConfig;
    public Action OnSaveIpConfig;
    public enum ConnectionStatus { Idle, NotConnected, TryingToConnect, Connected }
    public ConnectionStatus ConnectionStat;
    public enum SendingPermission { Allowed, NotAllowed }
    public SendingPermission Permission;

    [Header("UI Target Device UI")]
    public TMP_InputField TargetIPField;
    public TMP_InputField TargetPortField;

    [Header("UI Own Device UI")]
    public TMP_InputField OwnDevicePortField;
    public static OSCManager Instance { get; private set; }

    [SerializeField] private string scene;

    private List<ISendableData> activeList = new List<ISendableData>();
    private List<ISendableData> dataOutputsNonActiveList = new List<ISendableData>();

    private OscBundle oscBundle;
    private OSCSender sender;
    private OSCReceiver listener;
    private IPConfig config;
    private string FileName = "IpConfig";

    private StateMachine stateMachine;
    private Scratchpad scratchpad;

    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        SetScratchPad();
        CreateStateMachine();
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }
    private void OnDisable()
    {
        listener = scratchpad.Read<OSCReceiver>("Listener");
        listener.CloseListener();
    }
    public void CreateUDPSender()
    {
        if (sender != null) return;
        string targetIP = TargetIPField.text;
        int targetPort = Convert.ToInt32(TargetPortField.text);

        sender = new OSCSender(targetIP, targetPort);
        OnSaveIpConfig?.Invoke();
    }

    public void CreateUDPListener()
    {
        if (listener != null) return;

        int ownPort = Convert.ToInt32(OwnDevicePortField.text);

        listener = new OSCReceiver(ownPort);

        // set event listener
        if (listener != null)
        {
            //listener.OndataReceived += CheckIncomingMessage;
        }
    }

    public void SendMessage()
    {
        if (sender == null)
        {
            Debug.Log("create a Sender");
        }
        else
        {
            sender.SendMessage(oscBundle);
        }
    }
    public void ResetSender()
    {
        if (sender == null) return;
        sender.CloseSender();
        sender = null;
    }

    public void ResetListener()
    {
        if (listener == null) return;
        listener.CloseListener();
        listener = null;
    }

    public bool CheckSenderAvailable()
    {
        if (sender == null) return false;
        else return true;
    }
    public bool CheckListenerAvailable()
    {
        if (listener == null) return false;
        else return true;
    }

    public void AddDataOutputToList(ISendableData dataOutput)
    {
        dataOutputsNonActiveList.Add(dataOutput);
        dataOutput.OnActivation += ActivateItem;
        dataOutput.OnDeactivation += DeActivated;
    }

    private void ActivateItem(ISendableData data)
    {
        dataOutputsNonActiveList.Remove(data);
        activeList.Add(data);
    }

    private void DeActivated(ISendableData data)
    {
        dataOutputsNonActiveList.Add(data);
        activeList.Remove(data);
    }

    private void SetScratchPad()
    {
        scratchpad = new Scratchpad();
        scratchpad.Write("FileName", FileName);
        scratchpad.Write("Ip", TargetIPField);
        scratchpad.Write("Port", TargetPortField);
        scratchpad.Write("OwnPort", OwnDevicePortField);
        scratchpad.Write("Scene", scene);
        scratchpad.Write("ActiveList", activeList);
        //scratchpad.Write("Listener", listener);
        //scratchpad.Write("Sender", sender);
    }

    private void CreateStateMachine()
    {
        IState idleState = new PhaseNetworkingIdle(this);
        IState notConnectedPhase = new PhaseNotConnected(this);
        IState connectedPhase = new PhaseConnected(this, scratchpad, activeList);
        IState tryConnectionPhase = new PhaseTryConnecting(this, scratchpad);
        IState automaticConfigPhase = new PhaseAutomaticConfiguration(this, scratchpad);
        IState manualConfigPhase = new ManualConfigurationPhase(this, scratchpad);

        states.Add(typeof(PhaseNetworkingIdle), idleState);
        states.Add(typeof(PhaseNotConnected), notConnectedPhase);
        states.Add(typeof(PhaseConnected), connectedPhase);
        states.Add(typeof(PhaseTryConnecting), tryConnectionPhase);
        states.Add(typeof(PhaseAutomaticConfiguration), automaticConfigPhase);
        states.Add(typeof(ManualConfigurationPhase), manualConfigPhase);

        stateMachine = new StateMachine();
        stateMachine.SwitchState(automaticConfigPhase);
    }

    public void SwitchState<T>(T searchstate) where T : System.Type
    {
        if (states.TryGetValue(searchstate, out IState state))
        {
            stateMachine.SwitchState(state);
        }
    }

}
