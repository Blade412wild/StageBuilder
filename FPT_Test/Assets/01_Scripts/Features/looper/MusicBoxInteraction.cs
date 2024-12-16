using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject activatiorButton;
    [SerializeField] private GameObject deactivationButton;
    [SerializeField] private GameObject chooseButtons;
    [SerializeField] private ColliderInteraction collider;
    [SerializeField] private MusicBox musicBox;

    private bool choiceConfirmed = false;

    private void Start()
    {
        collider.OnTriggerExitEvent += CheckLeavingInteraction;
    }
    public void StartChooseInteraction()
    {
        musicBox.Source.clip = null;
        choiceConfirmed = false;
        activatiorButton.SetActive(false);
        chooseButtons.SetActive(true);
        gameObject.SetActive(true);
    }

    public void ConfirmChoice()
    {
        chooseButtons.SetActive(false);
        choiceConfirmed = true;
    }

    private void CheckLeavingInteraction()
    {
        //chooseButtons.SetActive(true);

        if (choiceConfirmed)
        {
            ExitInteraction();
        }
    }

    private void ExitInteraction()
    {
        activatiorButton.SetActive(true);
    }

}
