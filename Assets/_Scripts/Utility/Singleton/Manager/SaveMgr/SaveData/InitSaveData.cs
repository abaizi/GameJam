using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSaveData : MonoBehaviour
{
    [SerializeField] private Vector3 playerPos;
    [SerializeField] private Vector3 spherePos;

    private void Awake(){
        SaveMgr.Save<SaveJson>(new PlayerSaveData(playerPos, spherePos), PlayerSaveData.SaveFileName);
    }
}
