using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ShootEvent
{
    public float ForceMul;
    private static ShootEvent _e;

    public static void Invoke(float forceMul){
        _e.ForceMul = forceMul;
        EventMgr.Invoke<ShootEvent>(_e);
    }
}
