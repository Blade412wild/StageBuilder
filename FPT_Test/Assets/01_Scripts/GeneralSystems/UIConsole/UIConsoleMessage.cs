using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConsoleMessage : MonoBehaviour
{
    public event Action<CustomError2> OnMoreInformation;

    [SerializeField] public TMPro.TMP_Text Text;
    [SerializeField] public Image Icon;
    public CustomError2 CustomMessage;

    public void ActivateMoreInformationEvent()
    {
        OnMoreInformation?.Invoke(CustomMessage);
    }
}
