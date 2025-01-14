using UnityEngine;
public class PhaseNetworkingIdle : State<OSCManager>
{
    public PhaseNetworkingIdle(OSCManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("entered Networking IdleState");
        Owner.ConnectionStat = OSCManager.ConnectionStatus.Idle;
    }

    public override void OnExit()
    {

    }
}

