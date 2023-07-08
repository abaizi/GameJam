using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrap : Ground
{
    [SerializeField] private float _IdleDuration = 1;


    protected override void Awake(){
        base.Awake();
    }

    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        
        Destroy(gameObject, _IdleDuration);
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }
}
