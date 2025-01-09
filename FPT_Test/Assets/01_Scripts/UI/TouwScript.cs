using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouwScript : MonoBehaviour, IInteractible
{
    public UnityEvent events = new();
    public GameObject rope;


    // Start is called before the first frame update
    void Start()
    {
        rope = gameObject;
    }
    public void Activate()
    {
        events?.Invoke();
    }
}
