using System;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public class ManualConfigurationPhase : State<OSCManager>, ISaveableData
{

    [Header("UI Target Device UI")]
    private TMP_InputField ip;
    private TMP_InputField port;

    [Header("UI Own Device UI")]
    private TMP_InputField ownPort;

    private IPConfig config;
    private Scratchpad scratchpad;
    public ManualConfigurationPhase(OSCManager owner, Scratchpad scratchpad) : base(owner)
    {
        owner.OnSaveIpConfig += Save;

        this.scratchpad = scratchpad;

        FileName = scratchpad.Read<string>("FileName");
        Saver = new Saver();
    }

    public Saver Saver { get; set; }
    public Loader Loader { get; set; }
    public string FileName { get; set; }

    public override void OnEnter()
    {
        Debug.Log("entered Manual Configuration");
        config = scratchpad.Read<IPConfig>("IpConfig");
        ip = scratchpad.Read<TMP_InputField>("Ip");
        port = scratchpad.Read<TMP_InputField>("Port");
        ownPort = scratchpad.Read<TMP_InputField>("OwnPort");
    }

    public override void OnExit()
    {

    }

    public void Save()
    {
        IPConfig data = CreateIpConfig();
        Saver.SaveData<IPConfig>(data, FileName);
        scratchpad.Write("IpConfig", data, true);
        Debug.Log("saved Data");
    }
    public T Load<T>()
    {
        Loader = new Loader();
        T data = Loader.LoadData<T>(FileName); 
        return data;    
    }

    private IPConfig CreateIpConfig()
    {
        string targetIP = ip.text;
        int targetPort = Convert.ToInt32(port.text);
        int listeningport = Convert.ToInt32(ownPort.text);

        IPConfig iPConfig = new IPConfig()
        {
            Ip = targetIP,
            TargetPort = targetPort,
            ListeningPort = listeningport,
        };

        return iPConfig;
    }
}

