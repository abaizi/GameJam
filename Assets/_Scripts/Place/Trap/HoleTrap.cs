using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : Ground
{
    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);

        _ctrl.Die();
    }
}
