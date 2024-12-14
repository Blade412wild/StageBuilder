using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFloorDirection : State<StageSetupManager>
{
    private Transform floor;
    private Transform headTrans;
    private GameObject UI;
    private Timer timer;
    private StageSetupManager owner;

    public SetupFloorDirection(StageSetupManager owner, GameObject floor, Transform headTrans, GameObject UI) : base(owner)
    {
        this.owner = owner;
        this.floor = floor.transform;
        this.headTrans = headTrans;
        this.UI = UI;   
    }

    public override void OnEnter()
    {
        UI.SetActive(true);
        timer = new Timer(3);
        AddEvents();
    }
    public override void OnExit()
    {
        UI.SetActive(false);
    }

    private void SetDirection()
    {
        float directionY = headTrans.rotation.eulerAngles.y;
        Quaternion target = Quaternion.Euler(0, directionY, 0);
        floor.transform.rotation = target;
        floor.transform.position = new Vector3(headTrans.position.x, floor.position.y, headTrans.position.z);
        RemoveEvents();
    }

    private void AddEvents()
    {
        timer.OnTimerIsDone += SetDirection;
        timer.OnTimerIsDone += owner.GoToIdleState;
    }

    private void RemoveEvents()
    {
        timer.OnTimerIsDone -= SetDirection;
        timer.OnTimerIsDone -= owner.GoToIdleState;
    }

}
