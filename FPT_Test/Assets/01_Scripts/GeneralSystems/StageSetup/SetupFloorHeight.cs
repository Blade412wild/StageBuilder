using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorHeight : State<StageSetupManager>
{
    private Transform leftHandTrans;
    private Transform rightHandTrans;
    private Transform floor;
    private Transform headTrans;
    private GameObject UI;


    public SetupFloorHeight(StageSetupManager owner, GameObject rightHand, GameObject leftHand, GameObject floor, Transform headTrans, GameObject UI) : base(owner)
    {
        leftHandTrans = leftHand.transform;
        rightHandTrans = rightHand.transform;
        this.floor = floor.transform;
        this.headTrans = headTrans;
        this.UI = UI;
    }

    public override void OnEnter()
    {
        Debug.Log("enterd Floor height setup");
        SetFloorHeightToHandHeight();
        //UI.transform.position = new Vector3(UI.transform.position.x, headTrans.position.y, UI.transform.position.z);
        UI.SetActive(true);
    }

    public override void OnUpdate()
    {
        LowerFloor();
        //UI.transform.position = new Vector3(UI.transform.position.x, headTrans.position.y, UI.transform.position.z);
    }

    public override void OnExit()
    {
        UI.SetActive(false);
    }

    private void LowerFloor()
    {
        Vector3 lowestHand = CheckLowestHand();

        if (lowestHand.y > floor.position.y) return;
        floor.position = new Vector3(floor.position.x, lowestHand.y, floor.position.z);
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
        floor.position = new Vector3(floor.position.x, lowestHand.y - 0.3f, floor.position.z);
    }

}
