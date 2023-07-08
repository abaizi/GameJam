using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/IdleWater", fileName = "PlayerState_IdleWater")]
public class PlayerState_IdleWater : PlayerState
{
    [SerializeField] private float gravityScale = 0.01f;

    public override void Enter(){
        base.Enter();
        _data.ctrl.SetVelocityX(0);
        _data.ctrl.SetVelocityY(0);
        _data.ctrl.SetGravity(gravityScale);
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(!_data.ctrl.IsWater) ToIdle();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}
