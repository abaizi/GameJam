using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    public void LoadPlayer(){
        var data = SaveMgr.Load<SaveJson, PlayerSaveData>(PlayerSaveData.SaveFileName);
        playerPt.position = data.playerPos;
    } 


    public float volume;
    public AudioClip bgmClip;
    public AudioClip sfxClip;
    public Transform playerPt;



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
