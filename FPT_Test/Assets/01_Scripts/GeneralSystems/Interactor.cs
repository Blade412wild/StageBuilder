using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.TryGetComponent(out IInteractible interactible))
        {
            Debug.Log("activate");
            interactible.Activate();
        }
    }
}
