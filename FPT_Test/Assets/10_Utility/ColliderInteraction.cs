using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

public class ColliderInteraction : MonoBehaviour
{
    public event Action OnTriggerExitEvent;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Nose nose))
        {
            OnTriggerExitEvent.Invoke();
        }
    }

}
