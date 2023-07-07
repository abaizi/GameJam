using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Logic(){
        if(InputMgr.Inst.IsMove) ToWalk();
        else if(InputMgr.Inst.IsJump && _data.check.IsGround) ToJump();
        else if(_data.ctrl.IsFall) ToFall();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
        _data.ctrl.AddFriction();
    }
}
