using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkingUI : MonoBehaviour, IUI
{
    public IUI.TypeUI Type { get; set; }
    public bool Active { get; set; }
    public GameObject GameObject { get; set; }
    [SerializeField] private GameObject UIElement;

    private void Awake()
    {
        Type = IUI.TypeUI.BuilderMode;
        GameObject = UIElement;
    }

    private void Start()
    {
        Active = false;
        GameObject.SetActive(Active);
    }
    public void ChangeCurrentState()
    {
        if (Active)
        {
            GameObject.SetActive(false);
            //Debug.Log("zet uit");
            Active = false;
        }
        else
        {
            GameObject.SetActive(true);
            //Debug.Log("zet aan");
            Active = true;
        }
    }
}
