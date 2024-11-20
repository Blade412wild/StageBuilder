using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ConsoleMessageSpawner : MonoBehaviour
{
    private UIConsoleMessage uiMessage;
    private Transform parent;
    private ArtDataBase artDataBase;

    public ConsoleMessageSpawner(UIConsoleMessage uiMessage, Transform parent, ArtDataBase artDataBase)
    {
        this.uiMessage = uiMessage;
        this.parent = parent;
        this.artDataBase = artDataBase;
    }

    public void CheckMessagesList()
    {

    }

    public void SortMessageList(List<CustomError2> CustomMessages)
    {

    }

    public void CreateUIMessages(List<CustomError2> CustomMessages)
    {
        SortMessageList(CustomMessages);

        foreach (CustomError2 customMessage in CustomMessages)
        {
            UIConsoleMessage consoleMessage =  Instantiate(uiMessage, parent);
            consoleMessage.Text.text = customMessage.ShortMessage;

            if (customMessage.type == CustomError2.TypeMessage.Recommondation)
            {
                Debug.Log("artbase : " + artDataBase.RecommondationIcon);
                consoleMessage.Icon.sprite = artDataBase.RecommondationIcon;

            }

            if(customMessage.type == CustomError2.TypeMessage.FatalError)
            {
                consoleMessage.Icon.sprite = artDataBase.FatalIcon;

            }

            //consoleMessage.CustomMessage = customMessage;
        }
    }
}