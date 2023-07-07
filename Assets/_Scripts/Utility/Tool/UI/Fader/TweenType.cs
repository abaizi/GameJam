using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TweenDefinitionType{
    Tween, AnimCurve
}


[System.Serializable]
public class TweenType
{
    [SerializeField] private TweenDefinitionType definitionType = TweenDefinitionType.Tween; 
    [SerializeField] private Tween.TweenCurve tweenCurve = Tween.TweenCurve.EaseInCubic;
    [SerializeField] private AnimationCurve animCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    public TweenDefinitionType DefinitionType => definitionType;
    public Tween.TweenCurve TweenCurve => tweenCurve;
    public AnimationCurve AnimCurve => animCurve;

    public TweenType(Tween.TweenCurve tweenCurve){
        definitionType = TweenDefinitionType.Tween;
        this.tweenCurve = tweenCurve;
    }

    public TweenType(AnimationCurve animationCurve){
        definitionType = TweenDefinitionType.AnimCurve;
        this.animCurve = animationCurve;
    }
}
