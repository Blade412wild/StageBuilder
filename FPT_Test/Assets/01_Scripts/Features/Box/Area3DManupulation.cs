using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Area3DManupulation : MonoBehaviour, ISendableData
{
    public event Action<ISendableData> OnActivation;
    public event Action<ISendableData> OnDeactivation;
    Timer timer;

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
        //Debug.Log(name + " has been started");
        //OnActivation?.Invoke(this);
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

            timer = new Timer(0.1f);
            timer.OnTimerIsDone += DeactivateBox;
        }
    }
    public void AddItemToManager()
    {
        OSCManager.Instance.AddDataOutputToList(this);
        //Debug.Log("add : " + name + " to the nonactiveList");
    }

    private void DeactivateBox()
    {
        timer.OnTimerIsDone -= DeactivateBox;
        OnDeactivation?.Invoke(this);
    }
}