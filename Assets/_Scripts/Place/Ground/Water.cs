using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Ground
{
    protected override void OnPlayerTriggerEnter(Collider2D other){
        base.OnPlayerTriggerEnter(other);
        _ctrl.IsWater = true;
        _data.fsm.Switch(typeof(PlayerState_IdleWater));
    }

    protected override void OnPlayerTriggerStay(Collider2D other){
        base.OnPlayerTriggerStay(other);
    }

    protected override void OnPlayerTriggerExit(Collider2D other){
        base.OnPlayerTriggerExit(other);
        _ctrl.IsWater = false;
    }
}
