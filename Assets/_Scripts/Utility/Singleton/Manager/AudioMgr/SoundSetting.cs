using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Audio/SoundSetting", fileName = "SoundSetting")]
public class SoundSetting : ScriptableObject, ISaveData
{
    [Header("Arg")]
    public string MasterVolumeArg = "MasterVolume";
    public string BGMVolumeArg = "BGMVolume";
    public string SFXVolumeArg = "SFXVolume";
    public string VoiceVolumeArg = "VoiceVolume";
    public string UIVolumeArg = "UIVolume";

    [Header("Track")]
    public MasterTrack Master;
    public BGMTrack BGM;
    public SFXTrack SFX;
    public VoiceTrack Voice;
    public UITrack UI;


    public const float MinVolume = 0.0001f;
    public const float MaxVolume = 10f;
    public const float DefaultVolume = 1f;

    public void UpdateAllTrack(){
        Master.UpdateTrackVolume();
        BGM.UpdateTrackVolume();
        SFX.UpdateTrackVolume();
        Voice.UpdateTrackVolume();
        UI.UpdateTrackVolume();
    }
}
