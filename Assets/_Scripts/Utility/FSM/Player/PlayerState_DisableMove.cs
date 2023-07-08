using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/DisableMove", fileName = "PlayerState_DisableMove")]
public class PlayerState_DisableMove : PlayerState
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
