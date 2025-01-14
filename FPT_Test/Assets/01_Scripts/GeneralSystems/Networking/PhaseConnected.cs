using SharpOSC;
using System.Collections.Generic;
using UnityEngine;

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
        activeList = activeList;
    }

    public override void OnEnter()
    {
        sender = scratchpad.Read<OSCSender>("Sender");
        receiver = scratchpad.Read<OSCReceiver>("Listener");    
        Debug.Log("entered conntedPhase");
        Owner.ConnectionStat = OSCManager.ConnectionStatus.Connected;
    }

    public override void OnUpdate()
    {
        if (sender == null) return;
        //dataBundle = GetData();
    }

    public override void OnExit()
    {

    }

    private OscBundle GetData()
    {
        OscMessage[] oscMessages = new OscMessage[activeList.Count + 1];
        oscMessages[0] = new OscMessage(NamesSeperator + "Scene", scene);

        for (int i = 0; i < activeList.Count; i++)
        {
            OscMessage message = new OscMessage(NamesSeperator + activeList[i].Name, activeList[i].Data);
            Debug.Log(activeList[i].Name);
            oscMessages[i + 1] = message;
        }
        //Debug.Log(dataOutput);
        OscBundle bundle = new OscBundle(100, oscMessages);

        return bundle;
    }

}

