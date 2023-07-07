using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveBinaryEncrypt : SaveEncrypt, ISave
{
    public void Save(object data, string fileName){
        string path = $"{Application.persistentDataPath}/{fileName}";
        using (FileStream stream = File.Create(path)){
            using (MemoryStream memoryStream = new MemoryStream()){
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, data);
                
                memoryStream.Position = 0;
                Encrypt(memoryStream, stream, Key);
            }
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
            using (MemoryStream memoryStream = new MemoryStream()){
                Decrypt(stream, memoryStream, Key);
                memoryStream.Position = 0;

                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }

    public void Load(string fileName, object obj){
        throw new System.NotImplementedException();
    }

    protected override void Encrypt(Stream iStream, Stream oStream, string sKey){
        RijndaelManaged algorithm = new RijndaelManaged();
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sKey, Encoding.ASCII.GetBytes(saltText));

        algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
        algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

        CryptoStream stream = new CryptoStream(iStream, algorithm.CreateEncryptor(), CryptoStreamMode.Read);
        stream.CopyTo(oStream);
    }

    protected override void Decrypt(Stream iStream, Stream oStream, string sKey){
        RijndaelManaged algorithm = new RijndaelManaged();
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sKey, Encoding.ASCII.GetBytes(saltText));

        algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
        algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

        CryptoStream stream = new CryptoStream(iStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read);
        stream.CopyTo(oStream);
    }
}
