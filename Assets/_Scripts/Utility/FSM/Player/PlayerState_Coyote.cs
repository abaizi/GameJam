using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Coyote", fileName = "PlayerState_Coyote")]
public class PlayerState_Coyote : PlayerState
{
    [SerializeField] private float coyoteTime = 0.1f;

    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Logic(){
        if(InputMgr.Inst.IsJump) ToJump();
        else if(StateDuration > coyoteTime || !InputMgr.Inst.IsMove) ToFall();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}

