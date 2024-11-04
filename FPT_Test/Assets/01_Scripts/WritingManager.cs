using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingManager : MonoBehaviour
{
    [SerializeField] private InputFieldActivator[] inputFieldActivators;

    private void Start()
    {
        setEvents();
    }

    private void setEvents()
    {
        for(int i = 0; i < inputFieldActivators.Length; i++)
        {
            inputFieldActivators[i].OnFieldActivated += ActivateKeyboard;
        }

    }

    private void ActivateKeyboard(TMPro.TMP_InputField field)
    {
        Debug.Log("hey I'm datainput bla");
    }

}
