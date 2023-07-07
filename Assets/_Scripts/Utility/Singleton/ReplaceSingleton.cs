using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSingleton<T> : MonoBehaviour where T : ReplaceSingleton<T>
{
    private static T instance;
    public static T Inst => instance;
    private float initTime;
    public float InitTime => initTime;
    
    
    protected virtual void Awake(){
        if(instance == null){
            instance = this as T;
            DontDestroyOnLoad(this);
        }

        initTime = Time.time;
        foreach(var mgr in FindObjectsOfType<T>()){
            if(mgr.initTime < initTime){
                Destroy(mgr.gameObject);
            }
        }
    }
}
