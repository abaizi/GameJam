using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFactor
{
    private static Dictionary<System.Type, ISave> saveDict = new Dictionary<System.Type, ISave>();

    public static ISave Create<T>() where T : ISave{
        Type type = typeof(T);
        if(saveDict.TryGetValue(type, out ISave save)) return save;
        return saveDict[type] = Activator.CreateInstance<T>();
    }
}
