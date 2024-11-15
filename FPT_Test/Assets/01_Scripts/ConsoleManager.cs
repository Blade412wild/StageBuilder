using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    [Header("'Messages")]
    [SerializeField] private bool spawnMessages;
    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private List<GameObject> messages;

    [Header("Errors")]
    [SerializeField] private List<CustomError> customErrors = new List<CustomError>();

    private UIDynamicHeightScaler heightScaler;
    private VerticalLayoutGroup verticalLayoutGroup;

    private ErrorList errorList;




    // Start is called before the first frame update
    void Start()
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        heightScaler = GetComponent<UIDynamicHeightScaler>();

        customErrors.Add(new CustomError("hallo"));
        customErrors.Add(new CustomError("Lach eens :)"));
        customErrors.Add(new CustomError("hallo"));
        customErrors.Add(new CustomError("Lach eens :)"));
        customErrors.Add(new CustomError("hallo"));
        customErrors.Add(new CustomError("hallo"));
        customErrors.Add(new CustomError("Lach eens :)"));
        customErrors.Add(new CustomError("hallo"));
        customErrors.Add(new CustomError("Lach eens :)"));
        customErrors.Add(new CustomError("Lach eens :)"));
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMessages)
        {
            if (customErrors.Count == 0) return;

            foreach (var error in customErrors)
            {
                Instantiate(messagePrefab, transform);
            }


            // create container size
            float messageCount = customErrors.Count;
            float heightmessage = messagePrefab.GetComponent<RectTransform>().sizeDelta.y;
            float newHeight = messageCount * (heightmessage + verticalLayoutGroup.spacing);
            heightScaler.CalculateNewYPos(newHeight);

            spawnMessages = false;
        }
    }


    private void SpawnMessages()
    {

    }
}
