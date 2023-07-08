using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Ground
{
    [SerializeField] private float _sphereDrag = 5;

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


    protected override void OnSphereTriggerEnter(Collider2D other){
        base.OnSphereTriggerEnter(other);
        _rbSphere.drag = _sphereDrag;
    }

    protected override void OnSphereTriggerStay(Collider2D other){
        base.OnSphereTriggerStay(other);
    }

    protected override void OnSphereTriggerExit(Collider2D other){
        base.OnSphereTriggerExit(other);
        _rbSphere.drag = 0;
    }
}
