using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Button/Released", fileName = "ButtonState_Released")]
public class ButtonState_Released : ButtonState
{
    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Reason(){

    }
    
    public override void Logic(){
        if(IsFinish) ToIdle();
    }

    public override void Physics(){

    }
}