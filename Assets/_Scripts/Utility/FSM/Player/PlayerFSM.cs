using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : FSMBase
{
    private Animator _animator;
    private PlayerCtrl _ctrl;
    private PlayerCheck _check;

    private void Start(){
        SwitchOn(typeof(PlayerState_Idle));
    }

    protected override void Init(){
        _animator = GetComponent<Animator>();
        _ctrl = GetComponentInChildren<PlayerCtrl>();
        _check = GetComponentInChildren<PlayerCheck>();

        _data = new PlayerStateData(this, _animator, _ctrl, _check);
    }
}
