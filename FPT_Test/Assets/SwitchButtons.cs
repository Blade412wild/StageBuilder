using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour
{
    [SerializeField] bool switched;
    [SerializeField] private GameObject thisButton;
    [SerializeField] private GameObject otherButton;

    private void Start()
    {
        thisButton = gameObject;
        if (switched)
        {
            thisButton.SetActive(false);
        }

    }
    public void Swap()
    {
        if (!switched)
        {
            thisButton.SetActive(false);
            otherButton.SetActive(true);

            switched = true;
            otherButton.GetComponent<SwitchButtons>().switched = false;
        }
        else
        {
            thisButton.SetActive(true);
            otherButton.SetActive(false);

            switched = false;
            otherButton.GetComponent<SwitchButtons>().switched = true;
        }
    }
}
