using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    PlayerRefs playerRefs;
    [SerializeField] private Scenes scenes;

    private void Start()
    {
        scenes.CurrentScene = "Main";
    }


    public void QuiteGame()
    {
        Application.Quit();
    }
}
