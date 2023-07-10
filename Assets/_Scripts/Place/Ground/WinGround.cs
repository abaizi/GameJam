using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGround : Ground
{
    protected override void OnSphereTriggerEnter(Collider2D other){
        base.OnSphereTriggerEnter(other);
        SceneMgr.LoadScene(SceneMgr.CreditsScene);
    }
}
