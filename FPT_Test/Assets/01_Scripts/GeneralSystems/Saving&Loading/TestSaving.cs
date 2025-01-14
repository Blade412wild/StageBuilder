using System;
using UnityEngine;

public class TestSaving : MonoBehaviour, IDataAccess
{
    public string FileName { get; set; }
    public Action<IDataAccess,Type> OnLoadData { get; set; }
    public object Data { get; set; }

    private Saver saveManager;
    FileManager fileManager;

    private void Start()
    {
        saveManager = new Saver();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("ober I want to get the : Ipconfig");
            OnLoadData?.Invoke(this, typeof(IPConfig));
        }
    }
}
