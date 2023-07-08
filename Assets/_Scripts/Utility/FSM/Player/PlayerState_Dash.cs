using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Dash", fileName = "PlayerState_Dash")]
public class PlayerState_Dash : PlayerState
{
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashCD;

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
        if(StateDuration > dashDuration) ToIdle();
    }

    public override void Physics(){
        
    }
}
