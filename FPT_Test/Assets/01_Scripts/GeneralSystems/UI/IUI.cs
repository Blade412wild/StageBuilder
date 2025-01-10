using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IUI
{
    public enum TypeUI {BuilderMode, PerformanceMode }
    TypeUI Type { get; set; }
    bool Active { get; set; }

    public GameObject GameObject { get; set; }

    public void ChangeCurrentState();

    

}
