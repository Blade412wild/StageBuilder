using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    [Header("UICanvas")]
    [SerializeField] private RectTransform messageSpawnTransform;
    [SerializeField] private TMPro.TMP_Text moreInfoTextField;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;

    [Header("Messages")]
    [SerializeField] private bool spawnMessages;
    [SerializeField] private UIConsoleMessage consoleMessage;
    [SerializeField] private ArtDataBase artBase;

    [Header("Errors")]
    [SerializeField] private List<CustomError2> messages = new List<CustomError2>();


    private ConsoleMessageSpawner consoleMessageSpawner;
    private ScaleUIHeight scaleUIHeight;
    private List<UIConsoleMessage> uiMessages;

    // Start is called before the first frame update
    void Start()
    {
        //verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        consoleMessageSpawner = new ConsoleMessageSpawner(consoleMessage, messageSpawnTransform, artBase);
        scaleUIHeight = new ScaleUIHeight(messageSpawnTransform, verticalLayoutGroup);
        uiMessages = new List<UIConsoleMessage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMessages)
        {
            if (messages.Count == 0) return;

            if (uiMessages.Count > 0)
            {
                DestroyUIMessages();
            }

            SpawnMessages();

            // check eerst of de container wel veranderd hoeft te worden, het mag niet kleiner worden dan het scroll van
            ResizeContainer();

            spawnMessages = false;
        }
    }

    private void SpawnMessages()
    {
        uiMessages = consoleMessageSpawner.CreateUIMessages(messages);
        SubscribeEvents(uiMessages);
    }

    private void ResizeContainer()
    {
        // Change container size
        float messageCount = messages.Count;
        float heightmessage = consoleMessage.gameObject.GetComponent<RectTransform>().sizeDelta.y;
        float newHeight = messageCount * (heightmessage + verticalLayoutGroup.spacing);

        if (scaleUIHeight.CheckNewHeight(newHeight))
        {
            scrollRect.vertical = true;
            scaleUIHeight.CalculateNewYPos(newHeight);
        }
        else
        {
            scrollRect.vertical = false;
        }

    }

    private void SubscribeEvents(List<UIConsoleMessage> uiConsoleMessages)
    {
        foreach (UIConsoleMessage uIConsoleMessage in uiConsoleMessages)
        {
            uIConsoleMessage.OnMoreInformation += HandleRequestMoreInfo;
        }
    }

    private void UnsubscribeEvents(List<UIConsoleMessage> uiConsoleMessages)
    {
        foreach (UIConsoleMessage uIConsoleMessage in uiConsoleMessages)
        {
            uIConsoleMessage.OnMoreInformation -= HandleRequestMoreInfo;
        }
    }

    private void DestroyUIMessages()
    {
        UnsubscribeEvents(uiMessages);
        foreach (UIConsoleMessage uiMessage in uiMessages)
        {
            Destroy(uiMessage.gameObject);
        }
    }


    private void HandleRequestMoreInfo(CustomError2 message)
    {
        moreInfoTextField.text = message.DetailedMessage;
    }
}
