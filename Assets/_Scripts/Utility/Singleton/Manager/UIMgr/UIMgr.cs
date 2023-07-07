using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMgr : Singleton<UIMgr>
{
    private Dictionary<Type, UIBase> uIDict = new Dictionary<Type, UIBase>();

    protected override void Awake(){
        base.Awake();

        foreach(var uI in transform.GetAllComponent<UIBase>()){
            uIDict.Add(uI.GetType(), uI);
        }
    }

    public void SetVisable<T>(bool isVisable){
        Type type = typeof(T);
        if(!uIDict.ContainsKey(type)){
            Debug.LogError($"不存在该键: {type}");
            return;
        }

        uIDict[type].gameObject.SetActive(isVisable);
        if(isVisable){
            uIDict[type].OnOpen();
        }else{
            uIDict[type].OnClose();
        }
    }

    public void Open<T>() where T : UIBase => SetVisable<T>(true);
    public void Close<T>() where T : UIBase => SetVisable<T>(false);


    public bool IsOpen<T>() where T : UIBase{
        return uIDict[typeof(T)].gameObject.activeSelf;
    }

    public T GetUIBase<T>() where T : UIBase{
        return uIDict[typeof(T)] as T;
    }
}
