using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Die", fileName = "PlayerState_Die")]
public class PlayerState_Die : PlayerState
{
    [SerializeField] private float fadeOutDuration = 2;
    [SerializeField] private TweenType tweenType;

    public override void Enter(){
        base.Enter();

        FadeOutEvent.Invoke(fadeOutDuration, tweenType);
        _data.ctrl.Die();
    }

    public override void Exit(){
        base.Exit();

        _data.ctrl.Revive();
    }

    public override void Logic(){
        if(StateDuration > fadeOutDuration){
            SceneMgr.LoadScene(SceneMgr.PlaySceneName, true);
        }
    }

    public override void Physics(){

    }
}
