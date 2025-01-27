using System;
using TMPro;
using UnityEngine;
public class PhaseAutomaticConfiguration : State<OSCManager>, ISaveableData
{
    public Action OnConfigDone;
    public Saver Saver { get; set; }
    public Loader Loader { get; set; }
    public string FileName { get; set; }

    [Header("UI Target Device UI")]
    private TMP_InputField ip;
    private TMP_InputField port;
    private TMP_InputField ownPort;
    private Scratchpad scratchpad;

    private OSCSender sender;
    private OSCReceiver listener;

    private IPConfig config;

    public PhaseAutomaticConfiguration(OSCManager owner, Scratchpad scratchpad) : base(owner)
    {
        this.scratchpad = scratchpad;

        config = scratchpad.Read<IPConfig>("IpConfig");
        ip = scratchpad.Read<TMP_InputField>("Ip");
        port = scratchpad.Read<TMP_InputField>("Port");
        ownPort = scratchpad.Read<TMP_InputField>("OwnPort");
        FileName = scratchpad.Read<string>("FileName");

        Loader = new Loader();
    }

    public override void OnEnter()
    {
        config = Load<IPConfig>();

        if (config == null)
        {
            // <Go to Not Connected>
            Debug.Log("no config found");
            Owner.SwitchState(typeof(PhaseNotConnected));
        }
        else
        {
            Debug.Log("have found Config");
            SetUIElements(config);

            // first remove the existing sockets
            if(listener != null)
            {
                listener.CloseListener();
            }
            if(sender != null)
            {
                sender.CloseSender();
            }

            CreateUDPSender();
            CreateUDPListener();
            OnConfigDone?.Invoke();
            Owner.SwitchState(typeof(PhaseTryConnecting));
        }
    }
    public void CreateUDPSender()
    {
        string targetIP = ip.text;
        int targetPort = Convert.ToInt32(port.text);

        sender = new OSCSender(targetIP, targetPort);
        scratchpad.Write("Sender", sender, true);
    }

    public void CreateUDPListener()
    {
        int ownPortInt = Convert.ToInt32(ownPort.text);

        listener = new OSCReceiver(ownPortInt);
        scratchpad.Write("Listener", listener, true);
    }

    public void Save()
    {
        
    }

    public T Load<T>()
    {
        T data = Loader.LoadData<T>(FileName);
        scratchpad.Write("IpConfig", data, true);
        return data;    
    }
    private void SetUIElements(IPConfig data)
    {
        ip.text = data.Ip;
        port.text = data.TargetPort.ToString();
        ownPort.text = data.ListeningPort.ToString();
    }
}

