using SharpOSC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PhaseConnected : State<OSCManager>
{
    private OSCReceiver receiver;
    private OSCSender sender;

    private OscBundle dataBundle;

    private List<ISendableData> activeList = new List<ISendableData>();
    private List<ISendableData> dataOutputsNonActiveList = new List<ISendableData>();

    private string NamesSeperator = "/";
    private string dataSeperator = ":";
    private string scene;
    private Scratchpad scratchpad;


    public PhaseConnected(OSCManager owner, Scratchpad scratchpad, List<ISendableData> activeList) : base(owner)
    {
        this.scratchpad = scratchpad;
        scene = scratchpad.Read<string>("Scene");
        //activeList = activeList;
    }

    public override void OnEnter()
    {
        Owner.ConnectionStat = OSCManager.ConnectionStatus.Connected;
        sender = scratchpad.Read<OSCSender>("Sender");
        receiver = scratchpad.Read<OSCReceiver>("Listener");
        Debug.Log("entered conntedPhase");
    }

    public override void OnUpdate()
    {
        if (sender == null) return;
        if (Owner.Permission == OSCManager.SendingPermission.NotAllowed) return;
        dataBundle = GetData();
    }

    public override void OnExit()
    {
        sender.CloseSender();
    }

    private OscBundle GetData()
    {
        activeList = scratchpad.Read<List<ISendableData>>("ActiveList");
        OscMessage[] oscMessages = new OscMessage[activeList.Count + 1];
        oscMessages[0] = new OscMessage(NamesSeperator + "Scene", scene);

        for (int i = 0; i < activeList.Count; i++)
        {
            OscMessage message = new OscMessage(NamesSeperator + activeList[i].Name, activeList[i].Data);
            Debug.Log(activeList[i].Name);
            oscMessages[i + 1] = message;
        }
        //Debug.Log(dataOutput);
        Debug.Log(activeList.Count);
        OscBundle bundle = new OscBundle(100, oscMessages);

        return bundle;
    }

}

