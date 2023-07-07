using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : UIBase
{
    protected UnityEngine.UI.Button button;


    protected virtual void Awake(){
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => OnClick());
    }

    public virtual void OnClick(){

    }
}
