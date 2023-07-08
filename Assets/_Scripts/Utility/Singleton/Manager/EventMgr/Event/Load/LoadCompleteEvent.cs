using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LoadCompleteEvent{
    public string SceneName;

    private static LoadCompleteEvent e;

    public static void Invoke(string sceneName){
        
        e.SceneName = sceneName;
        EventMgr.Invoke<LoadCompleteEvent>(e);
        Debug.Log(2);
    }
}