using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveBinary : ISave
{
    public void Save(object data, string fileName){
        string path = $"{Application.persistentDataPath}/{fileName}";
        using (FileStream stream = File.Create(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
        
        Debug.Log($"已保存至路径: {path}");
    }

    public T Load<T>(string fileName) where T : ISaveData{
        string path = $"{Application.persistentDataPath}/{fileName}";
        if(!File.Exists(path)){
            Debug.Log($"路径不存在: {path}");
            return default;
        }

        using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)){
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }

    public void Load(string fileName, object obj){
        throw new System.NotImplementedException();
    }
}
