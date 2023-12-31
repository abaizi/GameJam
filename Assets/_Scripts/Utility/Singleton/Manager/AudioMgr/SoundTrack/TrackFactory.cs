using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFactory
{
    private static Dictionary<TrackType, SoundTrack> trackDict = new Dictionary<TrackType, SoundTrack>();

    public static void Bulid(AudioSetting audioSetting){
        trackDict[TrackType.Master] = audioSetting.Sound.track.Master = new MasterTrack(audioSetting);
        trackDict[TrackType.BGM] = audioSetting.Sound.track.BGM = new BGMTrack(audioSetting);
        trackDict[TrackType.SFX] = audioSetting.Sound.track.SFX = new SFXTrack(audioSetting);
        trackDict[TrackType.Voice] = audioSetting.Sound.track.Voice = new VoiceTrack(audioSetting);
        trackDict[TrackType.UI] = audioSetting.Sound.track.UI = new UITrack(audioSetting);
    }

    public static SoundTrack Create(TrackType trackType){
        if(trackDict.TryGetValue(trackType, out SoundTrack track)){
            return track;
        }else{
            Debug.Log($"该类型未注册: {trackType}");
            return null;
        }
    }
}

