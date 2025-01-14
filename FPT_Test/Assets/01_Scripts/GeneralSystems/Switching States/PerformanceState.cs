using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceState : State<SwitchManager>
{
    private OSCManager oscManager;
    public PerformanceState(SwitchManager owner, OSCManager oscManager) : base(owner)
    {
        this.oscManager = oscManager;
    }

    public override void OnEnter()
    {
        Debug.Log("Entered Perfromance State");
        CheckInputList();
    }

    public override void OnUpdate()
    {
        oscManager.Permission = OSCManager.SendingPermission.Allowed;
    }

    public override void OnExit()
    {
        oscManager.Permission = OSCManager.SendingPermission.NotAllowed;
    }

    private void CheckInputList()
    {

    }
}
