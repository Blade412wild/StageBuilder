using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour, ISendableData
{
    public event Action<ISendableData> OnActivation;
    public event Action<ISendableData> OnDeactivation;

    public object Data { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; }

    private Vector2 data = new Vector2(0,0);

    private void Start()
    {
        Data = data;
        Name = "test";
        AddItemToManager();
        OnActivation?.Invoke(this);
    }

    public void AddItemToManager()
    {
        OSCManager.Instance.AddDataOutputToList(this);
    }
}
