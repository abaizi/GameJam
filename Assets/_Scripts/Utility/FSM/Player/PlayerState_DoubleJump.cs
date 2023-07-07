using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/DoubleJump", fileName = "PlayerState_DoubleJump")]
public class PlayerState_DoubleJump : PlayerState
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.1f;
    [SerializeField] private float fallGravityMul = 3f;

    public override void Enter(){
        base.Enter();

        _data.ctrl.Jump(jumpForce);
        _data.ctrl.HasDoubleJump = false;
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(InputMgr.Inst.IsJumpOver && StateDuration > jumpTime) _data.ctrl.SetGravity(fallGravityMul);

        if(_data.ctrl.IsFall) ToFall();
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}
