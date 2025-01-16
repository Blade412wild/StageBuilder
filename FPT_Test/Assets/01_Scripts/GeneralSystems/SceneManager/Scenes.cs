using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects", fileName = "ScriptableObjects/scenes")]
public class Scenes : ScriptableObject
{
    public string CurrentScene = "";

    public string sceneMenu;
    public string sceneHead;
    public string sceneBoxes;
    public string SceneLooper;
}
