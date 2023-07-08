using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrackType{
    Master, BGM, SFX, Voice, UI, Other
}

public enum TrackMode{
    Mute, Unmute, SetVolume
}

public class AudioMgr : PersistentSingleton<AudioMgr>, IEventListener<PlayAudioEvent>, IEventListener<SoundTrackEvent>, IEventListener<LoadStartEvent>
{
    [SerializeField] private AudioSetting audioSetting;

    private Dictionary<AudioSource, AudioData> playingAudioDict = new Dictionary<AudioSource, AudioData>();
    private AudioData audioData;

    private TweenType tweenType;


    private ManualPool pool;
    private const int PoolSize = 10;
    private const string Path = "Prefabs/Audio/AudioSource";



#region LifeCycle
    protected override void Awake(){
        base.Awake();
        
        Init();
    }

    private void Init(){
        Debug.Log(PoolMgr.Inst);
        pool = PoolMgr.Inst.CreateManaulPool(Path, PoolSize);
        tweenType = new TweenType(Tween.TweenCurve.EaseInOutCubic);
        TrackFactory.Bulid(audioSetting);
    }

    private void Start(){
        if(audioSetting.IsAutoLoad){
            audioSetting.LoadSoundSetting();
        }
    }


    private void OnEnable() {
        this.Register<PlayAudioEvent>();
        this.Register<SoundTrackEvent>();
        this.Register<LoadStartEvent>();
    }

    private void OnDisable() {
        this.Remove<PlayAudioEvent>();
        this.Remove<SoundTrackEvent>();
        this.Remove<LoadStartEvent>();
    }

#endregion

#region Audio

#region PlayAudio
    public void Invoke(PlayAudioEvent e){
        if(e.Clip == null){
            Debug.Log("AudioClip为空");
            return;
        }

        PlayAudio(e.Clip, e.Setting);
    }

    public void PlayBGM(AudioClip clip, bool isLoop = true){
        PlaySetting setting = new PlaySetting(TrackType.BGM, new NormalAudioSetting(isLoop), new SpecialAudioSetting());
        PlayAudioEvent.Invoke(clip, setting);
    }

    public void PlayBGM(AudioClip clip, NormalAudioSetting normalSetting){
        PlaySetting setting = new PlaySetting(TrackType.BGM, normalSetting, new SpecialAudioSetting());
        PlayAudioEvent.Invoke(clip, setting);
    }

    public void PlayBGM(AudioClip clip, NormalAudioSetting normalSetting, SpecialAudioSetting specialSetting){
        PlaySetting setting = new PlaySetting(TrackType.BGM, normalSetting, specialSetting);
        PlayAudioEvent.Invoke(clip, setting);
    }


    public void PlaySFX(AudioClip clip, bool isLoop = false){
        PlaySetting setting = new PlaySetting(TrackType.SFX, new NormalAudioSetting(isLoop), new SpecialAudioSetting());
        PlayAudioEvent.Invoke(clip, setting);
    }

    public void PlayVoice(AudioClip clip, bool isLoop = false){
        PlaySetting setting = new PlaySetting(TrackType.Voice, new NormalAudioSetting(isLoop), new SpecialAudioSetting());
        PlayAudioEvent.Invoke(clip, setting);
    }

    public void PlayUI(AudioClip clip, bool isLoop = false){
        PlaySetting setting = new PlaySetting(TrackType.UI, new NormalAudioSetting(isLoop), new SpecialAudioSetting());
        PlayAudioEvent.Invoke(clip, setting);
    }


    private void PlayAudio(AudioClip clip, PlaySetting playSetting){
        if(playSetting.Source == null){
            playSetting.Source = pool.GetFromPool().GetComponent<AudioSource>();
        }
        playSetting.SetAudioSource(clip);

        AudioSource source = playSetting.Source;
        switch(playSetting.TrackType){
            case TrackType.Master:
                source.outputAudioMixerGroup = audioSetting.MasterGroup;
                break;
            case TrackType.BGM:
                source.outputAudioMixerGroup = audioSetting.BGMGroup;
                break;
            case TrackType.SFX:
                source.outputAudioMixerGroup = audioSetting.SFXGroup;
                break;
            case TrackType.Voice:
                source.outputAudioMixerGroup = audioSetting.VoiceGroup;
                break;
            case TrackType.UI:
                source.outputAudioMixerGroup = audioSetting.UIGroup;
                break;
        }

        source.Play();

        if(playSetting.SpecialSetting.IsFade){
            StartFading(source, 0, playSetting.NormalSetting.Volume, playSetting.SpecialSetting.FadeDuration, tweenType);
        }

        if(playSetting.SpecialSetting.IsSolo){
            MuteAllAudio(source.clip.length);
        }

        if(!playSetting.NormalSetting.IsLoop){
            AutoCloseAudio(source, clip.length);
        }

        audioData.Init(playSetting.NormalSetting.ID, playSetting.TrackType, source, playSetting.SpecialSetting.IsPersistent);
        if(!playingAudioDict.ContainsKey(source)){
            playingAudioDict[source] = audioData;
        }
    }

#endregion

#region ControlAudio
    private void MuteAllAudio(float duration, bool isAutoUnmute = false){
        foreach(var source in playingAudioDict.Keys){
            source.mute = true;
        }

        if(isAutoUnmute) StartCoroutine(UnmuteAudioCoroutine(duration));
    }

    private IEnumerator UnmuteAudioCoroutine(float duration){
        yield return Timer.WaitForTime(duration);
        
        foreach(var source in playingAudioDict.Keys){
            source.mute = false;
        }
    }

    public void UnmuteAllAudio(){
        foreach(var source in playingAudioDict.Keys){
            source.mute = false;
        }
    }

    public void FreeAllAudio(bool isKeepPersistent = true){
        if(isKeepPersistent){
            FreeAllAudioButPersistent();
        }else{
            foreach(var source in playingAudioDict.Keys){
                FreeAudio(source);
            }
            playingAudioDict.Clear();
        }
    }

    private void FreeAllAudioButPersistent(){
        Dictionary<AudioSource, AudioData> dict = new Dictionary<AudioSource, AudioData>();
        foreach(var data in playingAudioDict.Values){
            if(data.IsPersistent){
                dict[data.Source] = data;
            }else{
                FreeAudio(data.Source);
            }
        }
        playingAudioDict = dict;
    }

    private void FreeAudio(AudioSource source){
        source.Stop();
        pool.ReturnToPool(source.gameObject);
    }

#endregion
    
#region CloseAudio
    private void AutoCloseAudio(AudioSource source, float duration){
        StartCoroutine(CloseAudioCoroutine(source, duration));
    }

    private IEnumerator CloseAudioCoroutine(AudioSource source, float duration){
        yield return Timer.WaitForTime(duration);
        FreeAudio(source);
        playingAudioDict.Remove(source);
    }

#endregion

#region FadeAduio
    private void StartFading(AudioSource source, float initVolume, float endVolume, float duration, TweenType tweenType){
        StartCoroutine(FadingCoroutine(source, initVolume, endVolume, duration, tweenType));
    }

    private IEnumerator FadingCoroutine(AudioSource source, float initVolume, float endVolume, float duration, TweenType tweenType){
        float timer = 0;
        while(timer < duration){
            source.volume = Tween.DoTween(timer, 0, duration, initVolume, endVolume, tweenType);
            yield return null;
            timer += Time.unscaledDeltaTime;
        }
    }

#endregion

#endregion

#region Track
    public void Invoke(SoundTrackEvent e){
        SoundTrack track = TrackFactory.Create(e.TrackType);
        // foreach(var data in playingAudioDict.Values){
        //     Debug.Log(data.Source.gameObject.name);
        // }
        switch (e.TrackOperation){
            case TrackOperation.MuteTrack:
                track.MuteTrack();
                break;
            case TrackOperation.UnmuteTrack:
                track.UnmuteTrack();
                break;
            case TrackOperation.SetVolumeTrack:
                track.SetTrackNormalVolume(e.Volume);
                break;
            case TrackOperation.PlayTrack:
                ForeachTrack(e.TrackType, data => data.Source.Play());
                break;
            case TrackOperation.PauseTrack:
                ForeachTrack(e.TrackType, data => data.Source.Pause());
                break;
            case TrackOperation.StopTrack:
                ForeachTrack(e.TrackType, data => data.Source.Stop());
                break;
            case TrackOperation.FreeTrack:
                FreeTrack(e.TrackType);
                break;
        }
    }

    private void FreeTrack(TrackType trackType){
        Dictionary<AudioSource, AudioData> dict = new Dictionary<AudioSource, AudioData>();

        foreach(var data in playingAudioDict.Values){
            if(data.TrackType == trackType){
                data.Source.Stop();
                pool.ReturnToPool(data.Source.gameObject);
            }else{
                dict[data.Source] = data;
            }
        }
        playingAudioDict = dict;
    }

    private void ForeachTrack(TrackType trackType, System.Action<AudioData> action){
        foreach(var data in playingAudioDict.Values){
            if(data.TrackType == trackType){
                action.Invoke(data);
            }
        }
    }

#endregion

#region SaveLoad
    public void SaveSetting(){
        audioSetting.SaveSoundSetting();
    }

    public void LoadSetting(){
        audioSetting.LoadSoundSetting();
    }

    public void Invoke(LoadStartEvent e){
        FreeAllAudioButPersistent();
    }
    #endregion

}
