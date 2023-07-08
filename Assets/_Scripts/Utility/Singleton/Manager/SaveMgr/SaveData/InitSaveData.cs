using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSaveData : MonoBehaviour
{
    [SerializeField] private Vector3 position;

    private void Awake(){
        SaveMgr.Save<SaveJson>(new PlayerSaveData(position), PlayerSaveData.SaveFileName);
    }
}
