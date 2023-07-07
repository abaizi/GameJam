using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventRegisterEx
{
    public static void Register<T>(this IEventListener<T> call) where T : struct{
        EventMgr.AddListener<T>(call);
    }

    public static void Remove<T>(this IEventListener<T> call) where T : struct{
        EventMgr.RemoveListener<T>(call);
    }
}
