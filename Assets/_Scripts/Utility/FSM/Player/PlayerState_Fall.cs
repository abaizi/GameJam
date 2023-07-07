using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] private float hangTime = 0.07f;
    [SerializeField] private float hangSpeedMul = 1.7f;
    [SerializeField] private float hangAcceMul = 2f;

    private float speedMul = 1;
    private float acceMul = 1;

    public override void Enter(){
        base.Enter();

        _data.ctrl.SetFallGravity();
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(InputMgr.Inst.IsJump){
            if(_data.ctrl.HasDoubleJump) ToDoubleJump();
            else InputMgr.Inst.EnableJumpBuffer();
        }else if(_data.check.IsGround) ToLand();

        HangInAir();
    }

    public override void Physics(){
        _data.ctrl.MoveX(speedMul, acceMul);
    }


    private void HangInAir(){
        if(StateDuration < hangTime){
            speedMul = hangSpeedMul;
            acceMul = hangAcceMul;
        }else{
            speedMul = 1;
            acceMul = 1;
        }
    }
}
