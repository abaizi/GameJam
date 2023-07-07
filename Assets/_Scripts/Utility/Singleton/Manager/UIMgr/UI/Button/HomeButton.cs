using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : LoadSceneButton
{
    protected override void Awake(){
        base.Awake();
        _sceneName = SceneMgr.StartSceneName;
    }
}
