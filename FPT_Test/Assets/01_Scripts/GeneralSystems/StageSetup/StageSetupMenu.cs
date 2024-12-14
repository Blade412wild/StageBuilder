using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetupMenu : State<StageSetupManager>
{
    private GameObject UIMenu;
    private Transform headTrans;
    private GameObject UI;
    public StageSetupMenu(StageSetupManager owner,Transform headTrans ,GameObject UIMenu, GameObject UI) : base(owner)
    {
        this.UI = UI;
        this.UIMenu = UIMenu;
        this.headTrans = headTrans;
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
