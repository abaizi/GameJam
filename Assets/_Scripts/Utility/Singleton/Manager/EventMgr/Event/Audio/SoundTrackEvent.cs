public enum TrackOperation{
    MuteTrack, UnmuteTrack, SetVolumeTrack, PlayTrack, PauseTrack, StopTrack, FreeTrack
}


public struct SoundTrackEvent
{
    public TrackOperation TrackOperation;
    public TrackType TrackType;
    public float Volume;

    private static SoundTrackEvent e;


    public static void Invoke(TrackOperation trackOperation, TrackType trackType, float volume = 1){
        e.TrackOperation = trackOperation;
        e.TrackType = trackType;
        e.Volume = volume;

        EventMgr.Invoke<SoundTrackEvent>(e);
    }
}
