using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Dash", fileName = "PlayerState_Dash")]
public class PlayerState_Dash : PlayerState
{
    [SerializeField] private float dashSpeed = 20;
    [SerializeField] private float dashDistance = 5;
    [SerializeField] private float dashCD = 2;

    private float dashDuration;

    public override void Enter(){
        base.Enter();
        _data.ctrl.StartDashTimer(dashCD);
        _data.ctrl.HasDash = false;
        _data.ctrl.SetGravity(0);
        _data.ctrl.SetVelocityX(dashSpeed * _data.ctrl.Dir);

        dashDuration = dashDistance / dashSpeed;
    }

    public override void Exit(){
        base.Exit();
        _data.ctrl.SetGravity(1);
        _data.ctrl.SetVelocityX(0);
    }

    public override void Logic(){
        if(StateDuration > dashDuration){
            if(_data.check.IsGround) ToIdle();
            else ToFall();
        }else if(_data.ctrl.CanAim) ToAim();
    }

    public override void Physics(){
        
    }
}
