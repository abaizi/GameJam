using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform savePt;

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerSaveData data = new PlayerSaveData(savePt.position);
        SaveMgr.Save<SaveJson>(data, PlayerSaveData.SaveFileName);
        GetComponent<Collider2D>().enabled = false;
    }
}
