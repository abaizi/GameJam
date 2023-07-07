using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class SaveEncrypt
{
    protected string saltText = "saltText";

    public string Key {get; set;} = "key";


    protected abstract void Encrypt(Stream iStream, Stream oStream, string sKey);

    protected abstract void Decrypt(Stream iStream, Stream oStream, string sKey);
}
