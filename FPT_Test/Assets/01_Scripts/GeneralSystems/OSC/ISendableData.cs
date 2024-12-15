using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public interface ISendableData
{
    public event Action<ISendableData> OnActivation;
    public event Action<ISendableData> OnDeactivation;

    object Data { get; set; }
    bool Active { get; set; }
    string Name { get; set; }

    void AddItemToManager();
}
