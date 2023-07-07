using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public enum TweenCurve{
        Linear,
        EaseInCubic, EaseOutCubic, EaseInOutCubic,
        EaseInQuad, EaseOutQuad, EaseInOutQuad
    }

    public static float DoTween(float curTime, float initTime, float endTime, float initVal, float endVal, TweenType tweenType){
        if(tweenType.DefinitionType == TweenDefinitionType.Tween){
            return DoTween(curTime, initTime, endTime, initVal, endVal, tweenType.TweenCurve);
        }else{
            return DoTween(curTime, initTime, endTime, tweenType.AnimCurve);
        }
    }

    public static float DoTween(float curTime, float initTime, float endTime, float initVal, float endVal, TweenCurve curve){
        float val = Math.Remap(curTime, initTime, endTime, initVal, endVal);
        switch(curve){
            case TweenCurve.Linear:
                val = TweenDefinition.Linear(val); break;
            case TweenCurve.EaseInCubic:
                val = TweenDefinition.EaseInCubic(val); break;
            case TweenCurve.EaseOutCubic:
                val = TweenDefinition.EaseOutCubic(val); break;
            case TweenCurve.EaseInOutCubic:
                val = TweenDefinition.EaseInOutCubic(val); break;
            case TweenCurve.EaseInQuad:
                val = TweenDefinition.EaseInQuad(val); break;
            case TweenCurve.EaseOutQuad:
                val = TweenDefinition.EaseOutQuad(val); break;
            case TweenCurve.EaseInOutQuad:
                val = TweenDefinition.EaseInOutQuad(val); break;
        }
        return val;
    }

    public static float DoTween(float curTime, float initTime, float endTime, AnimationCurve curve){
        return curve.Evaluate(Math.Remap(curTime, initTime, endTime, 0, 1));
    }

}
