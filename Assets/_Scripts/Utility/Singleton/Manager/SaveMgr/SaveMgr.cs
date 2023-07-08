using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveMgr
{
    public static string Suffix = ".dat";


    public static void Save<T>(SaveData data, string fileName) where T : ISave{
        SaveFactor.Create<T>().Save(data, fileName + Suffix);
    }


    public static U Load<T, U>(string fileName) where T : ISave where U : SaveData{
        return SaveFactor.Create<T>().Load<U>(fileName + Suffix);
    }

    public static void Load<T>(string fileName, object obj) where T : ISave{
        SaveFactor.Create<T>().Load(fileName + Suffix, obj);
    }


    public static void Delete(string fileName){
        string path = $"{Application.persistentDataPath}/{fileName + Suffix}";
        if(!File.Exists(path)){
            Debug.Log($"路径不存在: {path}");
            return;
        }

        File.Delete(path);
        Debug.Log($"已删除文件: {path}");
    }
}
