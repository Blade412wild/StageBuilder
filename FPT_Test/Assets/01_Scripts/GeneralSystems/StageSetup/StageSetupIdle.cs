using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetupIdle : State<StageSetupManager>
{
    private GameObject setup;
    public StageSetupIdle(StageSetupManager owner, GameObject setup) : base(owner)
    {
        this.setup = setup;
    }

    public override void OnEnter()
    {
        setup.SetActive(false);
    }

    public override void OnExit()
    {
        setup.SetActive(true);
    }
}
