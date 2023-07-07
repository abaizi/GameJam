using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : ButtonBase
{
    public override void OnClick(){
        UIMgr.Inst.GetUIBase<PausePanel>().Use();
    }
}
