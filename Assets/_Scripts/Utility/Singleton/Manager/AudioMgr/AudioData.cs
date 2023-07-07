using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AudioData
{
    public int ID;
    public TrackType TrackType;
    public AudioSource Source;
    public bool IsPersistent;

    public void Init(int id, TrackType trackType, AudioSource source, bool IsPersistent){
        this.ID = id;
        this.TrackType = trackType;
        this.Source = source;
        this.IsPersistent = IsPersistent;
    }
}
