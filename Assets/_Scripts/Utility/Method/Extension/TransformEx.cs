using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TransformEx
{
    public static T[] GetAllComponent<T>(this Transform parent, bool isIncludeParent = false){
        List<T> cmps = new List<T>();
        if(isIncludeParent) cmps.Add(parent.GetComponent<T>());

        ForeachChild(parent, child => {
            if(child.gameObject.TryGetComponent<T>(out T cmp)) cmps.Add(cmp);
        });

        return cmps.ToArray();
    }

    public static void ForeachChild(Transform parent, Action<Transform> action){
        if(parent.childCount == 0) return;

        for(int i = 0; i < parent.childCount; ++i){
            action.Invoke(parent.GetChild(i));
            ForeachChild(parent.GetChild(i), action);
        }
    }
}
