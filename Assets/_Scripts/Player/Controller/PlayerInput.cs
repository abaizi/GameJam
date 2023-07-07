using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerInputType{
        Player, UI
    }

    [SerializeField] private PlayerInputType inputType = PlayerInputType.Player;

    private void OnEnable(){ 
        if(inputType == PlayerInputType.Player) InputMgr.Inst.EnablePlayerInput();
        else if(inputType == PlayerInputType.UI) InputMgr.Inst.EnableUIInput();
    }

    private void OnDisable(){
        if(inputType == PlayerInputType.Player) InputMgr.Inst.DisablePlayerInput();
        else if(inputType == PlayerInputType.UI) InputMgr.Inst.DisableUIInput();
    }
}
