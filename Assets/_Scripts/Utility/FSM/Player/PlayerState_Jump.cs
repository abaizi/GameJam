using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Jump", fileName = "PlayerState_Jump")]
public class PlayerState_Jump : PlayerState
{
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float jumpTime = 0.1f;
    [SerializeField] private float fallGravityMul = 3f;

    public override void Enter(){
        base.Enter();

        _data.ctrl.Jump(jumpForce);
        InputMgr.Inst._buffer.IsJumpBuffer = false;
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(InputMgr.Inst.IsJumpOver && StateDuration > jumpTime) _data.ctrl.SetGravity(fallGravityMul);

        if(_data.ctrl.IsFall) ToFall();
        else if(InputMgr.Inst.IsJump) ToDoubleJump();
        else if(_data.ctrl.CanDash) ToDash();
        else if(_data.ctrl.CanAim) ToAim();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}
