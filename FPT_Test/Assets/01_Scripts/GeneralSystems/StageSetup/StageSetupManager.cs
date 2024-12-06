using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StageSetupManager : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;

    private StateMachine setupStateMachine;
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();


    // Start is called before the first frame update
    void Start()
    {
        SeptupStatemMachine();
        GoToIdleState();
    }

    // Update is called once per frame
    void Update()
    {
        if (setupStateMachine == null) return;
        setupStateMachine.OnUpdate();
    }

    private void SeptupStatemMachine()
    {
        IState setupFloorHeightState = new SetupFloorHeight(this, rightHand, leftHand, floor);
        IState setupFloorSizeState = new SetupFloorSize(this);
        IState setupStageIdle = new StageSetupIdle(this);

        states.Add(typeof(SetupFloorHeight), setupFloorHeightState);
        states.Add(typeof(SetupFloorSize), setupFloorSizeState);
        states.Add(typeof(StageSetupIdle), setupStageIdle);

        setupStateMachine = new StateMachine(setupFloorHeightState, setupFloorSizeState, setupStageIdle);
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

    public void GoToIdleState()
    {
        if (states.TryGetValue(typeof(StageSetupIdle), out IState state))
        {
            setupStateMachine.SwitchState(state);
        }
    }
}
