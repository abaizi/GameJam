using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase : MonoBehaviour, IState
{
    [SerializeField] protected List<StateBase> _states = new List<StateBase>();
    protected Dictionary<System.Type, IState> _stateDict;

    protected IState _curState;
    protected StateData _data;

    public IState CurState => _curState;


#region LifeCycle
    protected void Awake(){
        _stateDict = new Dictionary<System.Type, IState>(_states.Count);
        Init();

        foreach(var state in _states){
            state.Init(_data);
            _stateDict[state.GetType()] = state;
        }
    }

    protected virtual void Init(){

    }

    private void Update(){
        _curState.Reason();
        _curState.Logic();
    }

    private void FixedUpdate(){
        _curState.Physics();
    }

    private void OnGUI(){
        GUIStyle style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 30; 
        GUI.Label(new Rect(20, 20, 200, 200), $"当前状态: {_curState.GetType()}", style);
    }

#endregion

    public void SwitchOn(IState newState){
        if(newState == null){
            Debug.Log($"该状态为空: {newState}");
            return;
        }

        _curState = newState;
        _curState.Enter();
    }

    public void SwitchOn(System.Type type){
        SwitchOn(_stateDict[type]);
    }

    public void Switch(IState newState){
        _curState.Exit();
        SwitchOn(newState);
    }

    public void Switch(System.Type type){
        Switch(_stateDict[type]);
    }


    public void Enter(){

    }

    public void Exit(){

    }

    public void Reason(){

    }

    public void Logic(){

    }

    public void Physics(){

    }
}
