using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOuputGenericTest : MonoBehaviour
{
    public static DataOuputGenericTest Instance { get; private set; }

    private List<ISendableData> activeList = new List<ISendableData>();
    private List<ISendableData> dataOutputsNonActiveList = new List<ISendableData>();



    [SerializeField] private List<MonoBehaviour> list;
    string NamesSeperator = "/";
    string dataSeperator = ":";

    //[SerializeField] private List<GenericDataOuput> list = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeList.Count <= 0) return;
        RunLoop();
    }

    public void AddDataOutputToList(ISendableData dataOutput)
    {
        dataOutputsNonActiveList.Add(dataOutput);
        dataOutput.OnActivation += ActivateItem;
        dataOutput.OnDeactivation += DeActivated;
    }

    private void RunLoop()
    {
        string dataOutput =  "";
        foreach (ISendableData data in activeList)
        {
            string smallDataOutput;

            var convertedData = ConvertOutputToString<object>(data.Data);

            smallDataOutput = NamesSeperator + data.Name + NamesSeperator + convertedData;
            dataOutput = dataOutput + smallDataOutput;
        }
        Debug.Log(dataOutput);
    }

    private T ConvertOutputToString<T>(T input)
    {
        input.ToString();
        return input;
    }

    private void ActivateItem(ISendableData data)
    {
        dataOutputsNonActiveList.Remove(data);
        activeList.Add(data);
    }

    private void DeActivated(ISendableData data)
    {
        dataOutputsNonActiveList.Add(data);
        activeList.Remove(data);
    }
}
