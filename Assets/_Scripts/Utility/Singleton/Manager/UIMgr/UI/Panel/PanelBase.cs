using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : UIBase
{
    protected bool isOpen = false;

    public void Use(){
        isOpen = !isOpen;

        if(isOpen){
            UIMgr.Inst.Open<PausePanel>();
        }else{
            UIMgr.Inst.Close<PausePanel>();
        }
    }
}
