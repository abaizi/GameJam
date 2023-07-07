using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FadeStopEvent
{
    public int ID;
    
    private static FadeStopEvent e;

    public static void StopFading(int id = 0){
        e.ID = id;
        EventMgr.Invoke<FadeStopEvent>(e);
    }
}
