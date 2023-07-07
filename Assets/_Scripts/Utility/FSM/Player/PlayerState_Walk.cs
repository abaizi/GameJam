using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Walk", fileName = "PlayerState_Walk")]
public class PlayerState_Walk : PlayerState
{
    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Logic(){
        if(!InputMgr.Inst.IsMove) ToIdle();
        else if(InputMgr.Inst.IsJump && _data.check.IsGround) ToJump();
        else if(!_data.check.IsGround) ToCoyote();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}