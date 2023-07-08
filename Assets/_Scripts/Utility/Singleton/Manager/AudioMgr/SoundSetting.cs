using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Audio/SoundSetting", fileName = "SoundSetting")]
public class SoundSetting : ScriptableObject
{
    [Header("Arg")]
    public string MasterVolumeArg = "MasterVolume";
    public string BGMVolumeArg = "BGMVolume";
    public string SFXVolumeArg = "SFXVolume";
    public string VoiceVolumeArg = "VoiceVolume";
    public string UIVolumeArg = "UIVolume";

    [Header("Track")]
    public TrackSaveData track;


    public const float MinVolume = 0.0001f;
    public const float MaxVolume = 10f;
    public const float DefaultVolume = 1f;

    public void UpdateAllTrack(){
        track.Master.UpdateTrackVolume();
        track.BGM.UpdateTrackVolume();
        track.SFX.UpdateTrackVolume();
        track.Voice.UpdateTrackVolume();
        track.UI.UpdateTrackVolume();
    }
}

[System.Serializable]
public class TrackSaveData : SaveData
{
    public MasterTrack Master;
    public BGMTrack BGM;
    public SFXTrack SFX;
    public VoiceTrack Voice;
    public UITrack UI;
}
