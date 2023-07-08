using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikyGround : Ground
{
    [SerializeField] private float _moveMul = 0.5f;
    [SerializeField] private float _jumpMul = 0.5f;


    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        
        _ctrl.RecordMul();
        _ctrl.JumpMul = _jumpMul;
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
