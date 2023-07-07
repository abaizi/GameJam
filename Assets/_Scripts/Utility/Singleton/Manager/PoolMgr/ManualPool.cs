using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualPool : Pool
{
    public ManualPool(string path, int size, Transform parent) : base(path, size, parent){

    }

    public override GameObject GetFromPool(){
        GameObject obj = prefabQue.Count > 0  ? prefabQue.Dequeue() : InitPrefab();
        obj.SetActive(true);

        return obj; 
    }

    public void ReturnToPool(GameObject obj){
        prefabQue.Enqueue(obj);
        obj.SetActive(false);
    }
}
