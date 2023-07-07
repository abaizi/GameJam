using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[ExecuteAlways]
public static class EventMgr
{
    // public static Dictionary<Type, List<IEventListenerBase>> listenerDict = new Dictionary<Type, List<IEventListenerBase>>();


    // public static void AddListener<T>(IEventListener<T> listener){
    //     Type type = typeof(T);

    //     if(!listenerDict.ContainsKey(type)){
    //         listenerDict[type] = new List<IEventListenerBase>(){listener};
    //     }else if(!IsListenerExist(type, listener)){
    //         listenerDict[type].Add(listener);
    //     }
    // }

    // private static bool IsListenerExist(Type type, IEventListenerBase listener){
    //     if(!listenerDict.TryGetValue(type, out List<IEventListenerBase> listeners)){
    //         return false;
    //     }
    //     return listeners.Contains(listener);
    // }

    // public static void RemoveListener<T>(IEventListener<T> listener) where T : struct{
    //     Type type = typeof(T);

    //     if(listenerDict.ContainsKey(type) && listenerDict[type].Contains(listener)){
    //         listenerDict[type].Remove(listener);
    //         if(listenerDict[type].Count == 0){
    //             listenerDict.Remove(type);
    //         }
    //     }
    // }

    // public static void Invoke<T>(T e) where T : struct{
    //     Type type = e.GetType();

    //     if(listenerDict.ContainsKey(type)){
    //         foreach(var listener in listenerDict[type]){
    //             (listener as IEventListener<T>).Invoke(e);
    //         }
    //     }
    // }

    public static Dictionary<Type, HashSet<IEventListenerBase>> listenerDict = new Dictionary<Type, HashSet<IEventListenerBase>>();


    public static void AddListener<T>(IEventListener<T> listener){
        Type type = typeof(T);

        if(listenerDict.TryGetValue(type, out HashSet<IEventListenerBase> set)){
            set.Add(listener);
        }else{
            listenerDict[type] = new HashSet<IEventListenerBase>(){listener};
        }
    }


    public static void RemoveListener<T>(IEventListener<T> listener) where T : struct{
        Type type = typeof(T);

        if(listenerDict.ContainsKey(type) && listenerDict[type].Contains(listener)){
            listenerDict[type].Remove(listener);
            if(listenerDict[type].Count == 0){
                listenerDict.Remove(type);
            }
        }
    }

    public static void Invoke<T>(T e) where T : struct{
        Type type = e.GetType();

        if(listenerDict.ContainsKey(type)){
            foreach(var listener in listenerDict[type]){
                (listener as IEventListener<T>).Invoke(e);
            }
        }
    }
}
