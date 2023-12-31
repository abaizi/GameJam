using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    public override void Enter(){
        base.Enter();

        _data.ctrl.HasDoubleJump = true;
        _data.ctrl.HasDash = true;
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Logic(){
        if(InputMgr.Inst._buffer.IsJumpBuffer) ToJump();
        else if(InputMgr.Inst.IsMove) ToWalk();
        else if(!InputMgr.Inst.IsMove) ToIdle();
        else if(_data.ctrl.CanDash) ToDash();
    }

    public override void Physics(){
        _data.ctrl.PlayerMoveX();
    }
}
