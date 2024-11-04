using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InputFieldActivator : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<TMPro.TMP_InputField> OnFieldActivated;

    private TMPro.TMP_InputField inputfield;

    private void Awake()
    {
        inputfield = gameObject.GetComponent<TMPro.TMP_InputField>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnFieldActivated?.Invoke(inputfield);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
