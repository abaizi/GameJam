using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener<T> : IEventListenerBase
{
    void Invoke(T e);
}
