using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : StateBase
{
    protected ButtonStateData _data => _stateData as ButtonStateData;

    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void Reason(){

    }

    public override void Logic(){

    }

    public override void Physics(){

    }

    public void ToClick() => _data.fsm.Switch(typeof(ButtonState_Click));
    public void ToIdle() => _data.fsm.Switch(typeof(ButtonState_Idle));
    public void ToPressed() => _data.fsm.Switch(typeof(ButtonState_Pressed));
    public void ToDisabled() => _data.fsm.Switch(typeof(ButtonState_Disabled));
    public void ToReleased() => _data.fsm.Switch(typeof(ButtonState_Released));
}
