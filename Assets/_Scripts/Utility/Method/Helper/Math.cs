using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Math
{
    public static float Lerp(float a, float b, float t){
        return b * t + a * (1 - t);
    }

    public static float Remap(float x, float a, float b, float c, float d){
        return ((x - a) / (b - a)) * (d - c) + c;
    }

    public static float Approach(float a, float b, float t){
        if(a < b){
            a += t;
            if(a > b){
                return b;
            }
        }else{
            a -= t;
            if(a < b){
                return b;
            }
        }

        return a;
    }

    public static float NormalToMixer(float volume){
        if(volume <= 0) volume = SoundSetting.MinVolume;
        return Mathf.Log10(volume) * 20;
    }

    public static float MixerToNormal(float volume){
        return Mathf.Pow(10, volume / 20);
    }
}
