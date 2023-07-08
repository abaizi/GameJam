using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson : ISave
{
    public void Save(object data, string fileName){
        string path = $"{Application.persistentDataPath}/{fileName}";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);

        Debug.Log($"已保存至路径: {path}");
    }

    public T Load<T>(string fileName) where T : SaveData{
        string path = $"{Application.persistentDataPath}/{fileName}";
        if(!File.Exists(path)){
            Debug.Log($"路径不存在: {path}");
            return default;
        }

        Debug.Log($"已加载路径: {path}");
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(json);
    }

    public void Load(string fileName, object obj){
        string path = $"{Application.persistentDataPath}/{fileName}";
        if(!File.Exists(path)){
            Debug.Log($"路径不存在: {path}");
            return;
        }

        Debug.Log($"已加载路径: {path}");
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, obj);
    }
}
