using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/JumpWater", fileName = "PlayerState_JumpWater")]
public class PlayerState_JumpWater : PlayerState
{
    [SerializeField] private float jumpForce = 10f;

    public override void Enter(){
        base.Enter();

        _data.ctrl.SetGravity(0);
        _data.ctrl.Jump(jumpForce);
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        if(IsFinish) ToIdleWater();
    }

    public override void Physics(){
        _data.ctrl.JumpInWater();
    }
}
