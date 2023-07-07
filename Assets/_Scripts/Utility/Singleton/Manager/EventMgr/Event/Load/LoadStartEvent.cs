using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LoadStartEvent{
    public string SceneName;

    private static LoadStartEvent e;

    public static void Invoke(string sceneName){
        e.SceneName = sceneName;
        EventMgr.Invoke<LoadStartEvent>(e);
    }
}
