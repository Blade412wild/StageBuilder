using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StageSetupManager : MonoBehaviour
{
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject RightHand;
    [SerializeField] GameObject LeftHand;

    private StateMachine setupStateMachine;
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();


    // Start is called before the first frame update
    void Start()
    {
        SeptupStatemMachine();
    }

    // Update is called once per frame
    void Update()
    {
        if (setupStateMachine == null) return;
        setupStateMachine.OnUpdate();
    }

    private void SeptupStatemMachine()
    {
        IState SetupFloorHeightState = new SetupFloorHeight(this);
        IState SetupFloorSizeState = new SetupFloorSize(this);

        states.Add(typeof(SetupFloorHeight), SetupFloorHeightState);
        states.Add(typeof(SetupFloorSize), SetupFloorSizeState);

        setupStateMachine = new StateMachine();
        //setupStateMachine.AddTransition(new Transition(SetupFloorHeightState, SetupFloorSizeState, GoToSetSize));
        setupStateMachine.SwitchState(SetupFloorHeightState);

    }

    public void GoToSetSize()
    {
        if (states.TryGetValue(typeof(SetupFloorSize), out IState state))
        {
            setupStateMachine.SwitchState(state);
        }
    }

    public void GoToSetHeight()
    {
        if (states.TryGetValue(typeof(SetupFloorHeight), out IState state))
        {
            setupStateMachine.SwitchState(state);
        }
    }
}
