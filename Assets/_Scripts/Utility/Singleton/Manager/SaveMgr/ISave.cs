using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ISave
{
    void Save(object data, string fileName);
    T Load<T>(string fileName) where T : SaveData;
    void Load(string fileName, object obj);
}
