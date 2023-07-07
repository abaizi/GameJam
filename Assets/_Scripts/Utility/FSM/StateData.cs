using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData
{
    public FSMBase fsm;
    public Animator animator;

    public StateData(FSMBase fsm, Animator animator){
        this.fsm = fsm;
        this.animator = animator;
    }
}

public class PlayerStateData : StateData
{
    public PlayerCtrl ctrl;
    public PlayerCheck check;

    public PlayerStateData(FSMBase fsm, Animator animator, PlayerCtrl ctrl, PlayerCheck check) : base(fsm, animator){
        this.ctrl = ctrl;
        this.check = check;
    }
}

public class ButtonStateData : StateData
{
    public CanvasGroup canvasGroup;
    public ButtonStateData(FSMBase fsm, Animator animator, CanvasGroup canvasGroup) : base(fsm, animator){
        this.canvasGroup = canvasGroup;
    }
}