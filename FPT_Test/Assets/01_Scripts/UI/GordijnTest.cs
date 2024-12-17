using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordijnTest : MonoBehaviour
{
    Animator animator;
    public bool isClosed = true;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    //void Update()
    //{
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ChangeState();
        //}
    //}

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
