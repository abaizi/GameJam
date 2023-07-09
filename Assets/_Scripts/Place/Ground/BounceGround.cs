using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGround : Ground
{
    [SerializeField] private float _bounce = 15;

    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        //_ctrl.AddForce(Vector2.up * _bounce, ForceMode2D.Impulse);
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }
}
