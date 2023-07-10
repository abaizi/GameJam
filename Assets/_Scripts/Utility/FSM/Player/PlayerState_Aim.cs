using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Aim", fileName = "PlayerState_Aim")]
public class PlayerState_Aim : PlayerState
{   
    [SerializeField] private float _fadeInDuration = 1;
    [SerializeField] private float _fadeOutDuration = 0.5f;
    [SerializeField] private float _timeScale = 0.1f;

    public override void Enter(){
        base.Enter();
        _data.check.StopAllCoroutines();
        _data.check.StartCoroutine(_data.ctrl.EffectSprite.FadeInCoroutine(_fadeInDuration));
        Time.timeScale = _timeScale;
    }

    public override void Exit(){
        base.Exit();
        _data.check.StopAllCoroutines();
        _data.check.StartCoroutine(_data.ctrl.EffectSprite.FadeOutCoroutine(_fadeOutDuration));
        Time.timeScale = 1;
    }

    public override void Logic(){
        if(!InputMgr.Inst.IsAim) ToShoot();
    }

    public override void Physics(){

    }
}
