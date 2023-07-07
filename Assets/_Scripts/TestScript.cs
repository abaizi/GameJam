using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    [InspectButton("PlayBGM")]
    public bool b1;

    [InspectButton("MuteBGM")]
    public bool b2;

    [InspectButton("UnmuteBGM")]
    public bool b3;

    [InspectButton("SetBGMVolume")]
    public bool b4;

    [InspectButton("PlayAudio")]
    public bool b5;

    [InspectButton("PlayBGMPersistent")]
    public bool b11;

    [InspectButton("PauseAudio")]
    public bool b6;

    [InspectButton("StopAudio")]
    public bool b7;

    [InspectButton("FreeAudio")]
    public bool b8;

    [InspectButton("Save")]
    public bool b9;

    [InspectButton("Load")]
    public bool b10;

    [InspectButton("LoadScene")]
    public bool b12;

    public float volume;
    public AudioClip bgmClip;
    public AudioClip sfxClip;



    private void PlayBGM(){
        AudioMgr.Inst.PlayBGM(bgmClip);
    }

    private void PlayBGMPersistent(){
        AudioMgr.Inst.PlayBGM(bgmClip, new NormalAudioSetting(true), new SpecialAudioSetting(true, false, true));
    }

    private void LoadScene(){
        SceneMgr.LoadScene("StartScene", true);
    }

    private void MuteBGM(){
        SoundTrackEvent.Invoke(TrackOperation.MuteTrack, TrackType.BGM);
    }

    private void UnmuteBGM(){
        SoundTrackEvent.Invoke(TrackOperation.UnmuteTrack, TrackType.BGM);
    }

    private void SetBGMVolume(){
        SoundTrackEvent.Invoke(TrackOperation.SetVolumeTrack, TrackType.BGM, volume);
    }

    private void PlayAudio(){
        SoundTrackEvent.Invoke(TrackOperation.PlayTrack, TrackType.BGM);
    }

    private void PauseAudio(){
        SoundTrackEvent.Invoke(TrackOperation.PauseTrack, TrackType.BGM);
    }

    private void StopAudio(){
        SoundTrackEvent.Invoke(TrackOperation.StopTrack, TrackType.BGM);
    }

    private void FreeAudio(){
        SoundTrackEvent.Invoke(TrackOperation.FreeTrack, TrackType.BGM);
    }

    private void Save(){
        AudioMgr.Inst.SaveSetting();
    }

    private void Load(){
        AudioMgr.Inst.LoadSetting();
    }
}
