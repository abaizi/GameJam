using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Shoot", fileName = "PlayerState_Shoot")]
public class PlayerState_Shoot : PlayerState
{
    [SerializeField] private float _shootForce = 40;
    [SerializeField] private float _bounce = 40;


    public override void Enter(){
        base.Enter();
        _data.ctrl.SetVelocityX(0);
        _data.ctrl.SetVelocityY(0);
        _data.ctrl.AddShootForce(_bounce);
        ShootEvent.Invoke(_shootForce);
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Logic(){
        if(_data.ctrl.IsFall) ToFall();
        else if(_data.check.IsGround) ToIdle();
    }

    public override void Physics(){
        _data.ctrl.PlayerMoveX();
    }
}
