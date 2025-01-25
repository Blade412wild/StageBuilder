using SharpOSC;
using System.Collections.Generic;
using UnityEngine;
public class PhaseTryConnecting : State<OSCManager>
{
    private Scratchpad scratchpad;
    private OSCReceiver listener;
    private OSCSender sender;
    private OscBundle bundle;
    public PhaseTryConnecting(OSCManager owner, Scratchpad scratchpad) : base(owner)
    {
        this.scratchpad = scratchpad;
    }

    public override void OnEnter()
    {
        Owner.ConnectionStat = OSCManager.ConnectionStatus.TryingToConnect;
        sender = scratchpad.Read<OSCSender>("Sender");
        listener = scratchpad.Read<OSCReceiver>("Listener");
        listener.OnConnectionMade += ConnectionIsMade;
        Debug.Log("entered TryConnectionPhase");
        CreateMessage();
    }

    public override void OnUpdate()
    {
        if (bundle == null) return;
        sender.SendMessage(bundle);
    }

    public override void OnExit()
    {
        listener.OnConnectionMade -= ConnectionIsMade;
    }

    private void CreateMessage()
    {
        string name = "/TestConnection";
        OscMessage connectionMessage = new OscMessage(name, 0);
        bundle = new OscBundle(100, connectionMessage);
    }

    private void ConnectionIsMade()
    {
        Owner.SwitchState(typeof(PhaseConnected));
    }
}

