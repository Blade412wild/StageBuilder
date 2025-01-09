using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private StageSetupManager stageSetupManager;
    [SerializeField] private SwitchManager switchManager;


    private void Start()
    {
        // eerst checken we of setupManager is nessary
        //stageSetupManager.Load();

        
    }

    private void Update()
    {
        
    }
}
