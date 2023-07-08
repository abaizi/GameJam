using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/JumpWater", fileName = "PlayerState_JumpWater")]
public class PlayerState_JumpWater : PlayerState
{
    [SerializeField] private float gravityScale = 0.5f;

    public override void Enter(){
        base.Enter();
        
        _data.ctrl.SetGravity(gravityScale);
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.SetGravity();
    }

    public override void Logic(){
        
    }

    public override void Physics(){
        _data.ctrl.MoveX();
    }
}
