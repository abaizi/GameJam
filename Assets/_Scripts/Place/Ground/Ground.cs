using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ground : Place
{
    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }

    protected override void OnPlayerTriggerEnter(Collider2D other){
        base.OnPlayerTriggerEnter(other);
    }

    protected override void OnPlayerTriggerStay(Collider2D other){
        base.OnPlayerTriggerStay(other);
    }

    protected override void OnPlayerTriggerExit(Collider2D other){
        base.OnPlayerTriggerExit(other);
    }

    protected override void OnSphereTriggerEnter(Collider2D other){
        base.OnSphereTriggerEnter(other);
    }

    protected override void OnSphereTriggerStay(Collider2D other){
        base.OnSphereTriggerStay(other);
    }

    protected override void OnSphereTriggerExit(Collider2D other){
        base.OnSphereTriggerExit(other);
    }
}
