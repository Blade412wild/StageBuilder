using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderState : State<SwitchManager>
{
    private GameObject light;
    private GameObject builderMode;
    public BuilderState(SwitchManager owner, GameObject light, GameObject builderMode) : base(owner)
    {
        this.light = light;
        this.builderMode = builderMode;
    }

    public override void OnEnter()
    {
        Debug.Log("Entered Builder State");
        light.SetActive(false);
        builderMode.SetActive(true);
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        light.SetActive(true);
        builderMode.SetActive(false);
    }

}
