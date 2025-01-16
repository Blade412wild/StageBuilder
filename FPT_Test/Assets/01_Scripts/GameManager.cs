using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnQuiteGame;
    [SerializeField] private StageSetupManager stageSetupManager;
    [SerializeField] private SwitchManager switchManager;
    [SerializeField] private OwnSceneManager ownSceneManager;
    [SerializeField] private PlayerRefs playerPrefs;


    private void Start()
    {
        ownSceneManager.OnSceneHeadEntered += HandleOnSceneHeadEntered;
        ownSceneManager.OnSceneHeadExited += HandleOnSceneHeadExited;
    }

    private void HandleOnSceneHeadEntered(Scenes scenes)
    {
        playerPrefs.Canvas.gameObject.SetActive(true);
        playerPrefs.HeadTracking.enabled = true;
        //playerPrefs.HeadTracking.Active = true;
        Debug.Log("have set : " + playerPrefs.HeadTracking + " to true");
        Debug.Log("have set : " + playerPrefs.Canvas + " to true");

    }
    private void HandleOnSceneHeadExited(Scenes scenes)
    {
        playerPrefs.Canvas.gameObject.SetActive(false); 
        playerPrefs.HeadTracking.enabled = false;

        Debug.Log("have set : " + playerPrefs.HeadTracking + " to false");
        Debug.Log("have set : " + playerPrefs.Canvas + " to false");
    }


    public void QuiteApplication()
    {
        OnQuiteGame?.Invoke();
    }
}
