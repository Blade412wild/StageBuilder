using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> : IState where T : MonoBehaviour
{
    public T Owner { get; protected set; }
    public State(T owner)
    {
        Owner = owner;
    }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }
}
