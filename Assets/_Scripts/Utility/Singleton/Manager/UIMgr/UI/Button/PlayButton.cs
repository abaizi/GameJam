using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : LoadSceneButton
{
    protected override void Awake(){
        base.Awake();
        _sceneName = SceneMgr.PlaySceneName;
    }


    public override void OnOpen(){

    }

    public override void OnClose(){

    }
}
