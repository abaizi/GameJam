using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Place : MonoBehaviour
{
    protected PlayerStateData _data;
    protected PlayerCtrl _ctrl;
    protected Collider2D _collider;


    protected virtual void Awake(){
        _collider = GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            OnPlayerEnter(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            OnPlayerStay(other);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            OnPlayerExit(other);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            OnPlayerTriggerEnter(other);
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            OnPlayerTriggerStay(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            OnPlayerTriggerExit(other);
        }
    }

    protected virtual void OnPlayerEnter(Collision2D other){
        _data = other.gameObject.GetComponentInParent<PlayerFSM>().Data;
        _ctrl = _data.ctrl;
    }

    protected virtual void OnPlayerStay(Collision2D other){

    }

    protected virtual void OnPlayerExit(Collision2D other){
        
    }


    protected virtual void OnPlayerTriggerEnter(Collider2D other){
        _data = other.gameObject.GetComponentInParent<PlayerFSM>().Data;
        _ctrl = _data.ctrl;
    }

    protected virtual void OnPlayerTriggerStay(Collider2D other){

    }

    protected virtual void OnPlayerTriggerExit(Collider2D other){
        
    }
}
