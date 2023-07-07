using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayAudioEvent
{
    public AudioClip Clip;
    public PlaySetting Setting;

    private static PlayAudioEvent e;


    public static void Invoke(AudioClip clip, PlaySetting setting){
        e.Clip = clip;
        e.Setting = setting;
        
        EventMgr.Invoke<PlayAudioEvent>(e);
    }
}
