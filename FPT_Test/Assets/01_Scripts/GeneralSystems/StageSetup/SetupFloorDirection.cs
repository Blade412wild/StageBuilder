using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorDirection : State<StageSetupManager>
{
    private Transform floor;
    private Transform headTrans;

    public SetupFloorDirection(StageSetupManager owner, GameObject floor, Transform headTrans) : base(owner)
    {
        this.floor = floor.transform;
        this.headTrans = headTrans;
    }

    public override void OnEnter()
    {
        float directionY = headTrans.rotation.eulerAngles.y;
        Quaternion target = Quaternion.Euler(0, directionY, 0);
        floor.transform.rotation = target;
        floor.transform.position = new Vector3(headTrans.position.x, floor.position.y, headTrans.position.z);

    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
    }

}
