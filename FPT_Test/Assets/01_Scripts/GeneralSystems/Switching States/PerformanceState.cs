using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceState : State<SwitchManager>
{
    public PerformanceState(SwitchManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Entered Perfromance State");
    }

    public override void OnUpdate()
    {
        Debug.Log("Perform");
    }

    public override void OnExit()
    {
    }
}
