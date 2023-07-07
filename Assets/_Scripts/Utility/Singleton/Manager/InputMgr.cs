using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMgr : Singleton<InputMgr>, PlayerInputAction.IPlayerActions, PlayerInputAction.IUIActions
{
    public PlayerInputBuffer _buffer;
    private PlayerInputAction _inputAction;
    

    public Vector2 MoveInput {get; private set;}
    public bool IsMove {get; private set;}
    public bool IsDash => _inputAction.Player.Jump.WasPressedThisFrame();
    public bool IsJumpOver {get; private set;}
    public bool IsJump => _inputAction.Player.Jump.WasPressedThisFrame();


    protected override void Awake(){
        base.Awake();

        _inputAction = new PlayerInputAction();
        _inputAction.Player.SetCallbacks(this);
        _inputAction.UI.SetCallbacks(this);
    }

    public void EnablePlayerInput(){
        DisableUIInput();

        _inputAction.Player.Enable();
    }

    public void EnableUIInput(){
        DisablePlayerInput();

        _inputAction.UI.Enable();
    }

    public void DisablePlayerInput(){
        _inputAction.Player.Disable();
    }

    public void DisableUIInput(){
        _inputAction.UI.Disable();
    }

    public void EnableJumpBuffer(){
        StopCoroutine(_buffer.JumpBufferCoroutine());
        StartCoroutine(_buffer.JumpBufferCoroutine());
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        IsMove = context.performed;
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        IsJumpOver = !context.performed;
        if(context.phase == InputActionPhase.Canceled){
            _buffer.IsJumpBuffer = false;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {

    }

    public void OnHanger(InputAction.CallbackContext context)
    {

    }

    public void OnEsc(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Started){
            UIMgr.Inst.GetUIBase<PausePanel>().Use();
        }
    }
}
