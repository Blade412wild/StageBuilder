using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorHeight : State<StageSetupManager>
{
    public SetupFloorHeight(StageSetupManager owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("enterd Floor height setup");
        // show UI for floor setuo
        // Reset Floor height to mid
        // Activate Hands
    }

    public override void OnExit()
    {
        // disable UI Floor Setup
    }

}
