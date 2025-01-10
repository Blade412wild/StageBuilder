using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnQuiteGame;
    [SerializeField] private StageSetupManager stageSetupManager;
    [SerializeField] private SwitchManager switchManager;


    private void Start()
    {

        
    }

    public void QuiteApplication()
    {
        OnQuiteGame?.Invoke();
    }
}
