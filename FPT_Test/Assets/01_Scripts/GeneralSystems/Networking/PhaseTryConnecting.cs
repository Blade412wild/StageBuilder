using UnityEngine;
public class PhaseTryConnecting : State<OSCManager>
{
    public PhaseTryConnecting(OSCManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("entered Try connectionPhase");
        Owner.ConnectionStat = OSCManager.ConnectionStatus.TryingToConnect;
    }

    public override void OnExit()
    {

    }

}

