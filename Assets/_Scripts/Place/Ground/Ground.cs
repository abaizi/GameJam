using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ground : Place
{
    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);

        _ctrl.RecordMul();
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }
}
