using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundTrack
{
    [SerializeField] [Range(SoundSetting.MinVolume, SoundSetting.MaxVolume)] protected float normalVolume = 1;
    [SerializeField] protected bool isEnable = true; 
    

    protected AudioSetting audioSetting;
    protected float mixerVolumeBeforeMute;
    protected string arg;


    public SoundTrack(AudioSetting audioSetting){
        this.audioSetting = audioSetting;
    }


    public virtual void SetTrackNormalVolume(float normalVolume){
        this.normalVolume = normalVolume;
        if(normalVolume <= 0) normalVolume = SoundSetting.MinVolume;
        else if(normalVolume > SoundSetting.MaxVolume) normalVolume = SoundSetting.MaxVolume;

        SetTrackMixerVolume(Math.NormalToMixer(normalVolume));
    }

    public virtual void MuteTrack(){
        audioSetting.Mixer.GetFloat(arg, out mixerVolumeBeforeMute);

        this.isEnable = false;
        SetTrackNormalVolume(0);
    }

    public virtual void UnmuteTrack(){
        this.isEnable = true;
        SetTrackMixerVolume(mixerVolumeBeforeMute);
    }

    public virtual void UpdateTrackVolume(){
        SetTrackMixerVolume(Math.NormalToMixer(normalVolume));
    }

    private void SetTrackMixerVolume(float mixerVolume){
        audioSetting.Mixer.SetFloat(arg, mixerVolume);
    }
}


[System.Serializable]
public class MasterTrack : SoundTrack
{
    public MasterTrack(AudioSetting audioSetting) : base(audioSetting){
        arg = audioSetting.Sound.MasterVolumeArg;
    }


    public override void SetTrackNormalVolume(float volume){
        base.SetTrackNormalVolume(volume);
    }

    public override void MuteTrack(){
        base.MuteTrack();
    }

    public override void UnmuteTrack(){
        base.UnmuteTrack();
    }
}


[System.Serializable]
public class BGMTrack : SoundTrack
{
    public BGMTrack(AudioSetting audioSetting) : base(audioSetting){
        arg = audioSetting.Sound.BGMVolumeArg;
    }


    public override void SetTrackNormalVolume(float volume){
        base.SetTrackNormalVolume(volume);
    }

    public override void MuteTrack(){
        base.MuteTrack();
    }

    public override void UnmuteTrack(){
        base.UnmuteTrack();
    }
}


[System.Serializable]
public class SFXTrack : SoundTrack
{
    public SFXTrack(AudioSetting audioSetting) : base(audioSetting){
        arg = audioSetting.Sound.SFXVolumeArg;
    }


    public override void SetTrackNormalVolume(float volume){
        base.SetTrackNormalVolume(volume);
    }

    public override void MuteTrack(){
        base.MuteTrack();
    }

    public override void UnmuteTrack(){
        base.UnmuteTrack();
    }
}


[System.Serializable]
public class VoiceTrack : SoundTrack
{
    public VoiceTrack(AudioSetting audioSetting) : base(audioSetting){
        arg = audioSetting.Sound.VoiceVolumeArg;
    }


    public override void SetTrackNormalVolume(float volume){
        base.SetTrackNormalVolume(volume);
    }

    public override void MuteTrack(){
        base.MuteTrack();
    }

    public override void UnmuteTrack(){
        base.UnmuteTrack();
    }

}


[System.Serializable]
public class UITrack : SoundTrack
{
    public UITrack(AudioSetting audioSetting) : base(audioSetting){
        arg = audioSetting.Sound.UIVolumeArg;
    }

    public override void SetTrackNormalVolume(float volume){
        base.SetTrackNormalVolume(volume);
    }

    public override void MuteTrack(){
        base.MuteTrack();
    }

    public override void UnmuteTrack(){
        base.UnmuteTrack();
    }
}
