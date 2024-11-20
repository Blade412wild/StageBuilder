using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    [Header("UICanvas")]
    [SerializeField] private Transform messageSpawnTransform;
    [SerializeField] private TMPro.TMP_Text moreInfoTextField;

    [Header("Messages")]
    [SerializeField] private bool spawnMessages;
    [SerializeField] private UIConsoleMessage consoleMessage;
    [SerializeField] private ArtDataBase artBase;
    [SerializeField] private List<UIConsoleMessage> uiConsoleMessages;

    [Header("Errors")]
    [SerializeField] private List<CustomError2> messages = new List<CustomError2>();


    private ConsoleMessageSpawner consoleMessageSpawner;
    private UIDynamicHeightScaler heightScaler;
    private VerticalLayoutGroup verticalLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        heightScaler = GetComponent<UIDynamicHeightScaler>();
        consoleMessageSpawner = new ConsoleMessageSpawner(consoleMessage, messageSpawnTransform, artBase);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMessages)
        {
            if (messages.Count == 0) return;

             SpawnMessages();

            // check eerst of de container wel veranderd hoeft te worden, het mag niet kleiner worden dan het scroll van
            ResizeContainer();

            spawnMessages = false;
        }
    }


    private void SpawnMessages()
    {
        List<UIConsoleMessage> uIConsoleMessages =  consoleMessageSpawner.CreateUIMessages(messages);
        SetEvents(uIConsoleMessages);
    }

    private void ResizeContainer()
    {
        // Change container size
        float messageCount = messages.Count;
        float heightmessage = consoleMessage.gameObject.GetComponent<RectTransform>().sizeDelta.y;
        float newHeight = messageCount * (heightmessage + verticalLayoutGroup.spacing);
        heightScaler.CalculateNewYPos(newHeight);
    }

    private void SetEvents(List<UIConsoleMessage> uiConsoleMessages)
    {
        foreach(UIConsoleMessage uIConsoleMessage in uiConsoleMessages)
        {
            uIConsoleMessage.OnMoreInformation += HandleRequestMoreInfo;
        }
    }



    private void HandleRequestMoreInfo(CustomError2 message)
    {
        Debug.Log(message);
        moreInfoTextField.text = message.DetailedMessage;
    }
}
