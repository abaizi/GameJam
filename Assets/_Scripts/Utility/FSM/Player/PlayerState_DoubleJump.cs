using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/DoubleJump", fileName = "PlayerState_DoubleJump")]
public class PlayerState_DoubleJump : PlayerState
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.1f;
    [SerializeField] private float fallGravityMul = 3f;

    public override void Enter(){
        base.Enter();

        AudioMgr.Inst.PlaySFX(clip);
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
        else if(_data.ctrl.CanDash) ToDash();
        else if(_data.check.IsGround) ToLand();
        else if(_data.ctrl.CanAim) ToAim();
    }

    public override void Physics(){
        _data.ctrl.PlayerMoveX();
    }
}
