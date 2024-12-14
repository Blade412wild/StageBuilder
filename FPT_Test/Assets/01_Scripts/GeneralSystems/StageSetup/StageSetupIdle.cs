using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetupIdle : State<StageSetupManager>
{
    private GameObject UIMenu;
    private GameObject UI;
    private Transform headTrans;
    public StageSetupIdle(StageSetupManager owner, Transform HeadTrans, GameObject UIMenu, GameObject UI) : base(owner)
    {
        this.UIMenu = UIMenu;
        this.UI = UI;
        this.headTrans = HeadTrans;
    }

    public override void OnEnter()
    {
        UI.transform.position = headTrans.position;
        Vector3 headRotationEuler = headTrans.rotation.eulerAngles;
        headRotationEuler = new Vector3(0, headRotationEuler.y, 0);

        UI.transform.rotation = Quaternion.Euler(headRotationEuler);
        UIMenu.SetActive(true);
    }

    public override void OnExit()
    {
        UIMenu.SetActive(false);
    }
}
