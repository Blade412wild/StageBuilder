using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Area3DManupulation : MonoBehaviour, ISendableData
{
    public event Action<ISendableData> OnActivation;
    public event Action<ISendableData> OnDeactivation;

    public object Data { get; set; }

    public bool Active { get; set; }
    public string Name { get; set; }

    [SerializeField] private int data = 0;
    [SerializeField] private string name;

    private void Start()
    {
        Data = data;
        Name = name;
        AddItemToManager();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Head head))
        {
            Data = 1;
            OnActivation?.Invoke(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Head head))
        {
            Data = 0;
            OnDeactivation?.Invoke(this);
        }
    }
    public void AddItemToManager()
    {
        DataOuputGenericTest.Instance.AddDataOutputToList(this);
    }
}