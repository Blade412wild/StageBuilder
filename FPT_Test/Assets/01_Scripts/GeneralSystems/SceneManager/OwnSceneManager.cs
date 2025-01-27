using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OwnSceneManager : MonoBehaviour
{
    public Action<Scenes> OnSceneHeadEntered;
    public Action<Scenes> OnSceneHeadExited;
    [SerializeField] private Scenes scenes; // scriptableObject

    private void Start()
    {
        if(scenes.CurrentScene == scenes.sceneHead)
        {
            OnSceneHeadEntered?.Invoke(scenes); // voor het activeren van headrotation feature.
            // dit werkt omdat er in elke scene een scenemanager zit.
        }
    }

    public void GoToMenu()
    {
        if (scenes.CurrentScene == scenes.sceneHead)
        {
            OnSceneHeadExited?.Invoke(scenes); // voor het deactiveren van headrotation feature.
        }

        scenes.CurrentScene = scenes.sceneMenu;

        SceneManager.LoadScene(scenes.sceneMenu);
    }

    public void GoToHead()
    {
        scenes.CurrentScene = scenes.sceneHead;
        SceneManager.LoadScene(scenes.sceneHead);
    }

    public void GoToBoxes()
    {

        scenes.CurrentScene = scenes.sceneBoxes;
        SceneManager.LoadScene(scenes.sceneBoxes);
    }

    public void GoToLooper()
    {
        scenes.CurrentScene = scenes.SceneLooper;
        SceneManager.LoadScene(scenes.SceneLooper);
    }
}
