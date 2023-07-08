using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/IdleWater", fileName = "PlayerState_IdleWater")]
public class PlayerState_IdleWater : PlayerState
{
    [SerializeField] private float fallSpeed = 1;

    public override void Enter(){
        base.Enter();
        _data.ctrl.DisableMove();
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(!_data.ctrl.IsWater) ToIdle();
        else if(InputMgr.Inst.IsMove) ToWalkWater();
        else if(InputMgr.Inst.IsJump) ToJumpWater();
    }

    public override void Physics(){
        _data.ctrl.SetVelocityY(-fallSpeed);
    }
}
