using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] private OSCManager oscManager;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject builderMode;
    [SerializeField] private GameObject performanceMode;
    private StateMachine switchMachine;
    private bool builderModeState = true;


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
        IState idleState = new IdleState(this);
        IState builderState = new BuilderState(this, light, builderMode);
        IState performanceState = new PerformanceState(this, oscManager);

        switchMachine = new StateMachine();

        switchMachine.AddTransition(new Transition(builderState, performanceState, ChangeToPerformance));
        switchMachine.AddTransition(new Transition(performanceState, builderState, ChangeToBuilder));

        switchMachine.SwitchState(idleState);

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
            foreach(CustomError error in errorList.list)
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

            if(errorList.FatalErrors == 0) return true;

            return false;
        }
    }

    private List<CustomError> CreateErrorList()
    {
        List<CustomError> errorList = new List<CustomError>();

        if (oscManager.CheckSenderAvailable() == false)
        {
            errorList.Add(new CustomError("There is No Sender, Fix that before you go into Perforance mode"));
        } 

        return errorList;
    }


    public void ChangeButtonState()
    {
        if (builderModeState)
        {
            builderModeState = false;
        }
        else
        {
            builderModeState = true;
        }
    }

}
