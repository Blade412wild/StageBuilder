using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDataOuput<T> : MonoBehaviour
{
    public T Value;

    public void SetValue(T value)
    {
        Value = value;
    }

    public T GetValue()
    {
        return Value;
    }
}
