using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetupFloorSize : State<StageSetupManager>
{
    public SetupFloorSize(StageSetupManager owner) : base(owner)
    {
        
    }

    public override void OnEnter()
    {
        Debug.Log("enterd Floor size setup");
        // show UI Floor sizeer
        // start tracking hand 
    }
}
