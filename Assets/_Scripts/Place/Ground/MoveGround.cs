using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : Ground
{
    [SerializeField] protected Transform _endPt;
    [SerializeField] protected float _moveSpeed;
    
    protected Vector3 _initPos;
    protected Vector3 _endPos;
    protected bool _isTurn = false;


    protected override void Awake(){
        base.Awake();

        _initPos = transform.position;
        _endPos = _endPt.position;
    }

    private void Update(){
        Move();
    }


    private void Move(){
        if(!_isTurn){
            transform.position = Vector3.MoveTowards(transform.position, _endPos, _moveSpeed * Time.deltaTime);
            if(Mathf.Approximately(Vector3.Distance(transform.position, _endPos), 0)){
                _isTurn = true;
            } 
        }else{
            transform.position = Vector3.MoveTowards(transform.position, _initPos, _moveSpeed * Time.deltaTime);
            if(Mathf.Approximately(Vector3.Distance(transform.position, _initPos), 0)) _isTurn = false;
        }
    }
}
