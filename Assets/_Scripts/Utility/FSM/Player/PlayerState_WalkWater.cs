using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/WalkWater", fileName = "PlayerState_WalkWater")]
public class PlayerState_WalkWater : PlayerState
{
    public override void Enter(){
        base.Enter();

        _data.ctrl.SetGravity(0);
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(!_data.ctrl.IsWater) ToJump();
        else if(!InputMgr.Inst.IsMove) ToIdleWater();
        else if(InputMgr.Inst.IsJump) ToJumpWater();
    }

    public override void Physics(){
        _data.ctrl.MoveInWater();
    }
}
