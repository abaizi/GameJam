using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MoveGround
{
    [SerializeField] private float _IdleDuration;

    private WaitForSeconds _waitForInterval;
    private bool canMove = true;


    protected override void Awake(){
        base.Awake();

        _waitForInterval = new WaitForSeconds(_IdleDuration);
        _initPos = transform.position;
        _endPos = _endPt.position;
    }

    private void Update(){
        if(!canMove) return;

        if(!_isTurn){
            transform.position = Vector3.MoveTowards(transform.position, _endPos, _moveSpeed * Time.deltaTime);
            if(Mathf.Approximately(Vector3.Distance(transform.position, _endPos), 0)){
                _isTurn = true;
                StartCoroutine(IdleTimer());
            } 
        }else{
            transform.position = Vector3.MoveTowards(transform.position, _initPos, _moveSpeed * Time.deltaTime);
            if(Mathf.Approximately(Vector3.Distance(transform.position, _initPos), 0)){
                _isTurn = false;
                StartCoroutine(IdleTimer());
            } 
        }
    }


    protected override void OnPlayerEnter(Collision2D other){
        base.OnPlayerEnter(other);

        _data.fsm.Switch(typeof(PlayerState_Die));
    }

    private IEnumerator IdleTimer(){
        canMove = false;
        yield return _waitForInterval;
        canMove = true;
    }
}
