using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrap : Ground
{
    [SerializeField] private float _IdleDuration = 1;
    private Animator anim;


    protected override void Awake(){
        anim = GetComponent<Animator>();
        base.Awake();
    }

    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);
        anim.SetTrigger("Broken");
        Destroy(gameObject, _IdleDuration);
    }

    protected override void OnPlayerStay(Collision2D other){
        base.OnPlayerStay(other);
    }

    protected override void OnPlayerExit(Collision2D other){
        base.OnPlayerExit(other);
    }
}
