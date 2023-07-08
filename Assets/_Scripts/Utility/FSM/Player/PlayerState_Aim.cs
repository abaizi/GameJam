using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Aim", fileName = "PlayerState_Aim")]
public class PlayerState_Aim : PlayerState
{
    [SerializeField] private float timeScale = 0.1f;

    public override void Enter(){
        base.Enter();

        Time.timeScale = timeScale;
    }

    public override void Exit(){
        base.Exit();

        Time.timeScale = 1;
    }

    public override void Logic(){
        if(!InputMgr.Inst.IsAim) ToShoot();
    }

    public override void Physics(){

    }
}
