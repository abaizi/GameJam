using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameEvent
{
    public string Name;

    private static GameEvent e;
    

    public static void Invoke(string name){
        e.Name = name;
    }
}
