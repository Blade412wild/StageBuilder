using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordijnTest : MonoBehaviour
{
    [SerializeField] private SwitchManager switchManager;
    Animator animator;
    public bool isClosed = true;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        switchManager.OnSwitchToPerformance += ChangeState;
        switchManager.OnSwitchToBuilder += ChangeState;
    }

    private void OnDisable()
    {
        switchManager.OnSwitchToPerformance -= ChangeState;
        switchManager.OnSwitchToBuilder -= ChangeState;
    }

    public void ChangeState()
    {
        if (isClosed)
        {
            animator.Play("Raise");
            isClosed = false;

        }
        else
        {
            animator.Play("Fall");
            isClosed = true;
        }
    }
}
