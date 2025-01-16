using System;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public Action OnSwitchToPerformance;
    public Action OnSwitchToBuilder;

    [SerializeField] private OSCManager oscManager;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject builderMode;
    [SerializeField] private GameObject performanceMode;
    [SerializeField] private StageSetupManager stageSetupManager;


    [Header("Bool")]
    [SerializeField] private bool StartOnBuildMode;
    [SerializeField] private bool StartOnStageSetup;

    private StateMachine stateMachine;
    private bool builderModeState = true;

    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    private void Start()
    {
        CreateStateMachine();

        // for debugging
        if (StartOnBuildMode == true && StartOnStageSetup == false)
        {
            GoToBuilderMode();
            stageSetupManager.GoToIdleState();
        }
        if (StartOnBuildMode == false && StartOnStageSetup == true)
        {
            Debug.Log("switch to stage");
            GoToIdleState();
            stageSetupManager.GoToMenu();
        }

        stageSetupManager.OnStageSetupDone += GoToBuilderMode;
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }

    private void CreateStateMachine()
    {
        IState idleState = new IdleState(this);
        IState builderState = new BuilderState(this, light, builderMode);
        IState performanceState = new PerformanceState(this, oscManager);

        states.Add(typeof(IdleState), idleState);
        states.Add(typeof(BuilderState), builderState);
        states.Add(typeof(PerformanceState), performanceState);

        stateMachine = new StateMachine();

        //stateMachine.AddTransition(new Transition(builderState, performanceState, ChangeToPerformance));
        //stateMachine.AddTransition(new Transition(performanceState, builderState, ChangeToBuilder));

        stateMachine.SwitchState(idleState);
    }

    private bool ChangeToPerformance()
    {
        if (builderModeState == false) return true;
        // check before going into perfromance mode if there is made a connection
        //checkErrorList();

        return false;
    }
    private bool ChangeToBuilder()
    {
        if (builderModeState) return true;
        return false;
    }

    private bool checkErrorList()
    {
        List<CustomError> customErrors = CreateErrorList();

        ErrorList errorList = new ErrorList(customErrors);

        if (errorList.list.Count <= 0) return true;

        else
        {
            foreach (CustomError error in errorList.list)
            {
                if (error.errorLevel == CustomError.ErrorLevel.Fatal)
                {
                    errorList.FatalErrors++;
                }

                if (error.errorLevel == CustomError.ErrorLevel.Recommondation)
                {
                    errorList.RecomdationErrors++;
                }
            }

            if (errorList.FatalErrors == 0) return true;

            return false;
        }
    }

    private List<CustomError> CreateErrorList()
    {
        List<CustomError> errorList = new List<CustomError>();

        if (oscManager.ConnectionStat != OSCManager.ConnectionStatus.Connected)
        {
            errorList.Add(new CustomError("You're not Connected to the the internet"));
        }

        return errorList;
    }


    public void ChangeButtonState()
    {
        if (builderModeState)
        {
            if (OSCManager.Instance.ConnectionStat != OSCManager.ConnectionStatus.Connected) return;
            builderModeState = false;
            SwitchState(typeof(PerformanceState));
            OnSwitchToPerformance?.Invoke();
        }
        else
        {
            builderModeState = true;
            SwitchState(typeof(BuilderState));
            OnSwitchToBuilder?.Invoke();
        }
    }

    public void GoToBuilderMode()
    {
        if (states.TryGetValue(typeof(BuilderState), out IState state))
        {
            // checks if this state isnt't already active
            if (stateMachine.currentState == state) return;
                stateMachine.SwitchState(state);
        }
    }
    public void GoToPerformanceMode()
    {
        if (states.TryGetValue(typeof(PerformanceState), out IState state))
        {
            // checks if this state isnt't already active
            if (stateMachine.currentState == state) return;
            stateMachine.SwitchState(state);
        }
    }
    public void GoToIdleState()
    {
        if (states.TryGetValue(typeof(IdleState), out IState state))
        {
            stateMachine.SwitchState(state);
        }
    }
    public void SwitchState<T>(T searchstate) where T : System.Type
    {
        if (states.TryGetValue(searchstate, out IState state))
        {
            stateMachine.SwitchState(state);
        }
    }

}
