using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : StateBase
{
    protected PlayerStateData _data => _stateData as PlayerStateData;

    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Reason(){

    }

    public override void Logic(){

    }

    public override void Physics(){

    }

    protected void ToIdle() => _data.fsm.Switch(typeof(PlayerState_Idle));
    protected void ToWalk() => _data.fsm.Switch(typeof(PlayerState_Walk));
    protected void ToDash() => _data.fsm.Switch(typeof(PlayerState_Dash));
    protected void ToCoyote() => _data.fsm.Switch(typeof(PlayerState_Coyote));
    protected void ToDoubleJump() => _data.fsm.Switch(typeof(PlayerState_DoubleJump));
    protected void ToFall() => _data.fsm.Switch(typeof(PlayerState_Fall));
    protected void ToJump() => _data.fsm.Switch(typeof(PlayerState_Jump));
    protected void ToLand() => _data.fsm.Switch(typeof(PlayerState_Land));
    protected void ToAim() => _data.fsm.Switch(typeof(PlayerState_Aim));
    protected void ToShoot() => _data.fsm.Switch(typeof(PlayerState_Shoot));

}
