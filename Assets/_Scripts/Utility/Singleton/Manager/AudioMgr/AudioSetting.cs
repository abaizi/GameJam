using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
[CreateAssetMenu(menuName = "Audio/AudioSetting", fileName = "AudioSetting")]
public class AudioSetting : ScriptableObject
{
    [Header("AudioMixer")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerGroup masterGroup;
    [SerializeField] private AudioMixerGroup bgmGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private AudioMixerGroup voiceGroup;
    [SerializeField] private AudioMixerGroup uiGroup;
    
    [Space(10)]
    [SerializeField] private SoundSetting soundSetting;
    [SerializeField] private bool isAutoLoad = true;

    private const string SaveFileName = "SoundSetting";


    public AudioMixer Mixer => mixer;
    public AudioMixerGroup MasterGroup => masterGroup;
    public AudioMixerGroup BGMGroup => bgmGroup;
    public AudioMixerGroup SFXGroup => sfxGroup;
    public AudioMixerGroup VoiceGroup => voiceGroup;
    public AudioMixerGroup UIGroup => uiGroup;
    public SoundSetting Sound => soundSetting;
    public bool IsAutoLoad => isAutoLoad;


    public void SaveSoundSetting(){
        SaveMgr.Save<SaveJson>(soundSetting, SaveFileName);
    }

    public void LoadSoundSetting(){
        SaveMgr.Load<SaveJson>(SaveFileName, soundSetting);
        soundSetting.UpdateAllTrack();
    }
}
