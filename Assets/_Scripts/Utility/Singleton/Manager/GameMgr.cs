using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : PersistentSingleton<GameMgr>, IEventListener<GameEvent>
{
    public void Invoke(GameEvent e){
        Debug.Log("GameMgr: " + e.Name);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void OnEnable(){
        this.Register<GameEvent>();
    }

    protected virtual void OnDisable(){
        this.Remove<GameEvent>();
    }
}
