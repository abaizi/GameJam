using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FadeInEvent
{
    public int ID;
    public float Duration;
    public TweenType TweenType;
    public bool IsIgnoreTimescale;

    private static FadeInEvent e;

    
    public static void Invoke(float duration, TweenType tweenType, int id = 0, bool isIgnoreTimescale = true){
        e.ID = id;
        e.Duration = duration;
        e.TweenType = tweenType;
        e.IsIgnoreTimescale = isIgnoreTimescale;
        EventMgr.Invoke<FadeInEvent>(e);
    }

    public static IEnumerator InvokeCoroutine(float duration, TweenType tweenType, int id = 0, bool isIgnoreTimescale = true){
        Invoke(duration, tweenType, id, isIgnoreTimescale);
        yield return Timer.WaitForTime(duration);
    }
}
