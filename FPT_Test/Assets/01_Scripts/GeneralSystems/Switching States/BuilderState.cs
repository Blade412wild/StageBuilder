using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderState : State<SwitchManager>
{
    public BuilderState(SwitchManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Entered Builder State");
    }

    public override void OnUpdate()
    {
        Debug.Log("Building");
    }

    public override void OnExit()
    {
    }




}
