using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _sphereSavePt;
    [SerializeField] private Transform _playerSavePt;

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerSaveData data = new PlayerSaveData(_playerSavePt.position, _sphereSavePt.position);
        SaveMgr.Save<SaveJson>(data, PlayerSaveData.SaveFileName);
        GetComponent<Collider2D>().enabled = false;
    }
}
