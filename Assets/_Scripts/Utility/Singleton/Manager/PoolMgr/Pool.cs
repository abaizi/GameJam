using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    protected Queue<GameObject> prefabQue = new Queue<GameObject>();
    protected Transform parent;
    protected string path;
    protected int size;


    public Pool(string path, int size, Transform parent){
        this.path = path;
        this.size = size;
        this.parent = parent;

        InitPool();
    }


    public void InitPool(){
        for(int i = 0; i < size; ++i){
            prefabQue.Enqueue(InitPrefab());
        }
    }

    public virtual GameObject GetFromPool(){
        GameObject obj = prefabQue.Count > 0 && !prefabQue.Peek().activeSelf ? prefabQue.Dequeue() : InitPrefab();
        obj.SetActive(true);
        prefabQue.Enqueue(obj);

        return obj; 
    }


    protected GameObject InitPrefab(){
        GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(path), parent);
        obj.SetActive(false);

        return obj;
    }

}
