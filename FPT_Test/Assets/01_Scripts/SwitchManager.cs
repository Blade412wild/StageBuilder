using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    private StateMachine switchMachine;
    private bool BuilderMode = false;

    private void Start()
    {
        CreateStateMachine();
    }

    private void Update()
    {
        switchMachine.OnUpdate();
    }

    private void CreateStateMachine()
    {

        IState builderState = new BuilderState(this);
        IState performanceState = new PerformanceState(this);

        switchMachine = new StateMachine();

        switchMachine.AddTransition(new Transition(builderState, performanceState, ChangeToPerformance));
        switchMachine.AddTransition(new Transition(performanceState, builderState, ChangeToBuilder));

        switchMachine.SwitchState(builderState);

    }

    private bool ChangeToPerformance()
    {
        if (BuilderMode == false) return true;
        return false;
    }
    private bool ChangeToBuilder()
    {
        if (BuilderMode) return true;
        return false;
    }


    public void ChangeButtonState()
    {
        if (BuilderMode)
        {
            BuilderMode = false;
        }
        else
        {
            BuilderMode = true;
        }
    }

}
