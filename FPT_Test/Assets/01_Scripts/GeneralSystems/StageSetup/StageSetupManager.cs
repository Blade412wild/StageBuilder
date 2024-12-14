using System;
using System.Collections.Generic;
using UnityEngine;

public class StageSetupManager : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private Transform headTrans;

    [Header("UI")]
    [SerializeField] private GameObject setup;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject UIMenu;
    [SerializeField] private GameObject UIFloor;
    [SerializeField] private GameObject UIDirection;


    private StateMachine setupStateMachine;
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();


    // Start is called before the first frame update
    void Start()
    {
        SeptupStatemMachine();
        //GoToIdleState();
        GoToSetHeight();
    }

    // Update is called once per frame
    void Update()
    {
        if (setupStateMachine == null) return;
        if (Input.GetKeyDown(KeyCode.M))
        {
            GoToSetDir();
        }
        setupStateMachine.OnUpdate();
    }

    private void SeptupStatemMachine()
    {
        IState setupStageIdle = new StageSetupIdle(this, setup);
        IState setupStageMenuState = new StageSetupMenu(this, headTrans, UIMenu, UI);
        IState setupFloorHeightState = new SetupFloorHeight(this, rightHand, leftHand, floor, headTrans, UIFloor);
        IState setupFloorSizeState = new SetupFloorSize(this);
        IState setupFloorDir = new SetupFloorDirection(this, floor, headTrans, UIDirection);

        states.Add(typeof(StageSetupIdle), setupStageIdle);
        states.Add(typeof(StageSetupMenu), setupStageMenuState);
        states.Add(typeof(SetupFloorHeight), setupFloorHeightState);
        states.Add(typeof(SetupFloorSize), setupFloorSizeState);
        states.Add(typeof(SetupFloorDirection), setupFloorDir);

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

    public void GoToSetDir()
    {
        if (states.TryGetValue(typeof(SetupFloorDirection), out IState state))
        {
            setupStateMachine.SwitchState(state);
        }
    }

    public void GoToMenu()
    {
        if (states.TryGetValue(typeof(StageSetupMenu), out IState state))
        {
            setupStateMachine.SwitchState(state);
        }
    }
}
