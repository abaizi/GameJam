using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Die", fileName = "PlayerState_Die")]
public class PlayerState_Die : PlayerState
{
    public override void Enter(){
        base.Enter();

        _data.ctrl.DisableMove();
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.ResetMul();
    }

    public override void Logic(){

    }

    public override void Physics(){

    }
}
