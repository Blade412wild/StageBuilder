using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseNotConnected : State<OSCManager> 
{
    public PhaseNotConnected(OSCManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("entered NotConnetedPhase");
        Owner.ConnectionStat = OSCManager.ConnectionStatus.NotConnected;
    }

    public override void OnExit()
    {

    }
}
