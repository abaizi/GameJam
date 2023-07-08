using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMgr : Singleton<PoolMgr>
{
    private Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    protected override void Awake(){
        base.Awake();
    }

    public Pool CreatePool(string path, int size){
        if(poolDict.TryGetValue(path, out Pool pool)){
            Debug.Log($"Pool已存在: {pool}");
            return pool;
        }else{
            Transform poolParent = new GameObject($"Pool: {Resources.Load<GameObject>(path).name}").transform;
            poolParent.parent = this.transform;
            return poolDict[path] = new Pool(path, size, poolParent);
        }
    }

    public ManualPool CreateManaulPool(string path, int size){
        if(poolDict.TryGetValue(path, out Pool pool)){
            Debug.Log($"ManualPool已存在: {pool}");
            return pool as ManualPool;
        }else{
            Transform poolParent = new GameObject($"Pool: {Resources.Load<GameObject>(path).name}").transform;
            poolParent.parent = this.transform;
            return (poolDict[path] = new ManualPool(path, size, poolParent)) as ManualPool;
        }
    }

    public Pool GetPool(string path){
        if(poolDict.TryGetValue(path, out Pool pool)){
            return pool;
        }else{
            Debug.Log($"Pool不存在: {path}");
            return null;
        }
    }
}
