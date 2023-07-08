using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TrapEvent
{
    public PlayerCtrl ctrl;

    private static TrapEvent _e;


    public static void Invoke(PlayerCtrl ctrl){
        _e.ctrl = ctrl;

        EventMgr.Invoke<TrapEvent>(_e);
    }
}
