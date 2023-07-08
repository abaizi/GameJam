using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTrap : MoveGround
{
    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);

        _data.fsm.Switch(typeof(PlayerState_Die));
    }


}
