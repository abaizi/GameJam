using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelGround : Ground
{
    [SerializeField] private float _moveMul = 2f;


    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        
        _ctrl.MoveMul = _moveMul;
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
        
        _ctrl.ResetMul();
    }
}
