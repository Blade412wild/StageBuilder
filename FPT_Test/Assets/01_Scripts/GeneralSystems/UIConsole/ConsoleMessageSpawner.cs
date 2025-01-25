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

    public List<CustomError> SortMessageList(List<CustomError> CustomMessages)
    {
       return CustomMessages.OrderBy(x => x.type).ToList();
    }

    public List<UIConsoleMessage> CreateUIMessages(List<CustomError> CustomMessages)
    {
        List<CustomError> newList =  SortMessageList(CustomMessages);
        List<UIConsoleMessage> uIConsoleMessages = new List<UIConsoleMessage>();

        foreach (CustomError customMessage in newList)
        {
            UIConsoleMessage consoleMessage =  Instantiate(uiMessage, parent);
            consoleMessage.Text.text = customMessage.ShortMessage;

            if (customMessage.type == CustomError.TypeMessage.Recommondation)
            {
                consoleMessage.Icon.sprite = artDataBase.RecommondationIcon;
            }

            if(customMessage.type == CustomError.TypeMessage.FatalError)
            {
                consoleMessage.Icon.sprite = artDataBase.FatalIcon;
            }

            consoleMessage.CustomMessage = customMessage;
            uIConsoleMessages.Add(consoleMessage);
        }

        return uIConsoleMessages;
    }
}
