using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : ScriptableObject, IState
{
    [SerializeField] private string _animName;
    protected StateData _stateData;

    private int _animHash;
    private float _startTime;

    public float StateDuration => Time.time - _startTime;
    public bool IsFinish => StateDuration >= _stateData.animator.GetCurrentAnimatorStateInfo(0).length;


    private void OnEnable(){
        _animHash = Animator.StringToHash(_animName);
    }


    public virtual void Init(StateData stateData){
        _stateData = stateData;
    }

    
    public virtual void Enter(){
        _startTime = Time.time;
        _stateData.animator.Play(_animHash);
    }

    public virtual void Exit(){

    }

    public virtual void Reason(){

    }

    public virtual void Logic(){

    }

    public virtual void Physics(){

    }
}
