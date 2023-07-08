using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTrap : Ground
{
    [SerializeField] private float _jumpCount = 2;

    private float _curJumpCount = 0;


    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        
        StartCoroutine(nameof(CheckCoroutine));
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }

    private IEnumerator CheckCoroutine(){
        _curJumpCount = 0;
        _data.fsm.Switch(typeof(PlayerState_DisableMove));

        while(true){
            Debug.Log(_curJumpCount);
            if(InputMgr.Inst.IsJump){
                if(++_curJumpCount >= _jumpCount){
                    _data.fsm.Switch(typeof(PlayerState_Jump));
                    yield break;
                }
            }

            yield return null;
        }
    }
}
