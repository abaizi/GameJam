using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSaveData : PersistentSingleton<InitSaveData>
{
    [SerializeField] private Transform initPt;

    protected override void Awake(){
        base.Awake();

        SaveMgr.Save<SaveJson>(new PlayerSaveData(initPt.position), PlayerSaveData.SaveFileName);
    }
}
