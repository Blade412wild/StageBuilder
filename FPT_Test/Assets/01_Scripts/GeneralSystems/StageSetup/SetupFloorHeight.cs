using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorHeight : State<StageSetupManager>
{
    private Transform leftHandTrans;
    private Transform rightHandTrans;
    private Transform floorVisual;
    private Transform headTrans;
    private GameObject UI;


    public SetupFloorHeight(StageSetupManager owner, GameObject rightHand, GameObject leftHand, GameObject floor, Transform headTrans, GameObject UI) : base(owner)
    {
        leftHandTrans = leftHand.transform;
        rightHandTrans = rightHand.transform;
        floorVisual = floor.transform;
        this.headTrans = headTrans;
        this.UI = UI;
    }

    public override void OnEnter()
    {
        Debug.Log("enterd Floor height setup");
        SetFloorHeightToHandHeight();
        UI.transform.position = new Vector3(UI.transform.position.x, headTrans.position.y, UI.transform.position.z);
        UI.SetActive(true);
        // show UI for floor setuo
        // Reset Floor height to mid
        // Activate Hands
    }

    public override void OnUpdate()
    {
        LowerFloor();
        UI.transform.position = new Vector3(UI.transform.position.x, headTrans.position.y, UI.transform.position.z);
        Debug.Log(headTrans.position.y);

    }

    public override void OnExit()
    {
        // disable UI Floor Setup
        UI.SetActive(false);
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
