using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OwnSceneManager : MonoBehaviour
{
    [SerializeField] private Scenes scenes;

    public void GoToMenu()
    {
        SceneManager.LoadScene(scenes.sceneMenu);
    }

    public void GoToHead()
    {
        SceneManager.LoadScene(scenes.sceneHead);
    }

    public void GoToBoxes()
    {
        SceneManager.LoadScene(scenes.sceneBoxes);
    }

    public void GoToLooper()
    {
        SceneManager.LoadScene(scenes.SceneLooper);
    }
}
