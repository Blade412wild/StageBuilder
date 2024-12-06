using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorHeight : State<StageSetupManager>
{
    private Transform leftHandTrans;
    private Transform rightHandTrans;
    private Transform floorVisual;


    public SetupFloorHeight(StageSetupManager owner, GameObject rightHand, GameObject leftHand, GameObject floor) : base(owner)
    {
        leftHandTrans = leftHand.transform;
        rightHandTrans = rightHand.transform;
        floorVisual = floor.transform;
    }

    public override void OnEnter()
    {
        Debug.Log("enterd Floor height setup");
        SetFloorHeightToHandHeight();
        // show UI for floor setuo
        // Reset Floor height to mid
        // Activate Hands
    }

    public override void OnUpdate()
    {
        LowerFloor();
    }

    public override void OnExit()
    {
        // disable UI Floor Setup
    }

    private void LowerFloor()
    {
        Vector3 lowestHand = CheckLowestHand();

        if (lowestHand.y > floorVisual.position.y) return;
        floorVisual.position = new Vector3(floorVisual.position.x, lowestHand.y, floorVisual.position.z);
    }

    private Vector3 CheckLowestHand()
    {
        if (leftHandTrans.position.y < rightHandTrans.position.y)
        {
            return leftHandTrans.position;
        }
        else
        {
            return rightHandTrans.position;
        }
    }

    private void SetFloorHeightToHandHeight()
    {
        Vector3 lowestHand = CheckLowestHand();
        floorVisual.position = new Vector3(floorVisual.position.x, lowestHand.y -0.3f, floorVisual.position.z);
    }

}
