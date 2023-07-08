using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFactory
{
    public static Dictionary<System.Type, Trap> trapDict = new Dictionary<System.Type, Trap>();

    public static Trap CreateTrap<T>() where T : Trap{
        System.Type type = typeof(T);
        if(trapDict.TryGetValue(type, out Trap trap)){
            return trap;
        }else{
            trap = System.Activator.CreateInstance<T>();
            trapDict[type] = trap;
            return trap;
        }
    }
}
