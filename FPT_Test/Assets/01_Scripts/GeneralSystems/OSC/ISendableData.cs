using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public interface ISendableData
{
    public event Action<ISendableData> OnActivation; // stuur data
    public event Action<ISendableData> OnDeactivation; // stop data versturen

    object Data { get; set; }
    bool Active { get; set; }
    string Name { get; set; }
    void AddItemToManager();
}
