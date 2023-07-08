using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Ground
{
    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }
}
