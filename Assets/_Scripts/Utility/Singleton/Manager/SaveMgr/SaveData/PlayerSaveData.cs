using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : SaveData
{
    public Vector3 playerPos;
    public Vector3 spherePos;
    public static string SaveFileName = "PlayerData";
    

    public PlayerSaveData(Vector3 position, Vector3 spherePos){
        this.playerPos = position;
        this.spherePos = spherePos;
    }
}
