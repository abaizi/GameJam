using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public struct SpecialAudioSetting
{
    public bool IsFade;
    public bool IsSolo;
    public bool IsPersistent;

    public float FadeDuration;

    public SpecialAudioSetting(bool isPersistent = false, bool isSolo = false, bool isFade = false, float fadeDuration = 2){
        IsPersistent = isPersistent;
        IsSolo = isSolo;
        IsFade = isFade;
        FadeDuration = fadeDuration;
    }

}

public struct NormalAudioSetting
{
    public Vector3 Position;
    public int ID;
    public float Volume;
    public bool IsLoop;


    public NormalAudioSetting(bool isLoop = false, int id = 0, float volume = 1){
        IsLoop = isLoop;
        ID = id;
        Volume = volume;
        Position = Vector3.zero;
    }

    public NormalAudioSetting(bool isLoop, int id, float volume, Vector3 position) : this(isLoop, id, volume){
        Position = position;
    }

}

[System.Serializable]
public class PlaySetting
{
    public TrackType TrackType;
    public AudioSource Source;
    public NormalAudioSetting NormalSetting;
    public SpecialAudioSetting SpecialSetting;


    public PlaySetting(TrackType trackType, NormalAudioSetting normalSetting, SpecialAudioSetting specialSetting){
        TrackType = trackType;
        NormalSetting = normalSetting;
        SpecialSetting = specialSetting;
    }


    public void SetAudioSource(AudioClip clip){
        Source.clip = clip;
        Source.transform.position = NormalSetting.Position;
        Source.volume = NormalSetting.Volume;
        Source.loop = NormalSetting.IsLoop;
    }
}
