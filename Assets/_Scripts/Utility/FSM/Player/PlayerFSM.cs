using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : FSMBase
{
    protected Animator _animator;
    protected PlayerCtrl _ctrl;
    protected GroundCheck _check;

    public PlayerStateData Data => _data as PlayerStateData;

    private void Start(){
        SwitchOn(typeof(PlayerState_Idle));
    }

    protected override void Init(){
        _animator = GetComponentInChildren<Animator>();
        _ctrl = GetComponentInChildren<PlayerCtrl>();
        _check = GetComponentInChildren<GroundCheck>();

        _data = new PlayerStateData(this, _animator, _ctrl, _check);
    }
}
