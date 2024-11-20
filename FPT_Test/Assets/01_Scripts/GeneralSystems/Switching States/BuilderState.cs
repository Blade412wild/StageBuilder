using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderState : State<SwitchManager>
{
    private GameObject light;
    public BuilderState(SwitchManager owner, GameObject light) : base(owner)
    {
        this.light = light;
    }

    public override void OnEnter()
    {
        Debug.Log("Entered Builder State");
        light.SetActive(false);
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        light.SetActive(true);
    }




}
