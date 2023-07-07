using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : PersistentSingleton<T>
{
    private static T instance;
    public static T Inst => instance;

    
    protected virtual void Awake(){
        if(instance == null){
            instance = this as T;
            DontDestroyOnLoad(this);
        }else if(this != instance){
            Destroy(gameObject);
        }
    }
}
