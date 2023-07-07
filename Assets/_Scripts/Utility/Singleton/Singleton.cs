using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Inst => instance;

    
    protected virtual void Awake(){
        if(instance == null){
            instance = this as T;
        }else if(this != instance){
            Destroy(gameObject);
        }
    }
}
