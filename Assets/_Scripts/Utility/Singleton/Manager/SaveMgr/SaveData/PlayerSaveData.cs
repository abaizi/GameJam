using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : SaveData
{
    public Vector3 position;
    public static string SaveFileName = "PlayerData";
    

    public PlayerSaveData(Vector3 position){
        this.position = position;
    }
}
