using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Image))]
[AddComponentMenu("Tool/GUI/Fader")]
public class Fader : MonoBehaviour, IEventListener<FadeInEvent>, IEventListener<FadeOutEvent>, IEventListener<FadeStopEvent>
{
    public enum FadeState{
        None, Active, Inactive
    }


    [Header("ID")]
    [SerializeField] private int id;

    [Header("Opacity")]
    [SerializeField] private float activeAlpha = 1;
    [SerializeField] private float inactiveAlpha = 0;
    [SerializeField] private FadeState state = FadeState.Inactive;

    [Header("Timing")]
    [SerializeField] private float defaultDuration = 1f;
    [SerializeField] private TweenType defaultTweenType = new TweenType(Tween.TweenCurve.Linear);
    [SerializeField] private bool isIgnoreTimescale = true;

    [Header("Interaction")]
    [SerializeField] private bool useBlockRaycasts = false;

    // [Header("Debug")]
    // [SerializeField] [InspectButton("FadeInSecond")] private bool FadeInSecondButton;
    // [SerializeField] [InspectButton("FadeOutSecond")] private bool FadeOutSecondButton;
    // [SerializeField] [InspectButton("DefaultFade")] private bool DefaultFadeButton;
    // [SerializeField] [InspectButton("ResetFader")] private bool ResetFaderButton;
    // [SerializeField] [InspectButton("StartFader")] private bool StartFaderButton;


    private CanvasGroup canvasGroup;
    private Image image;

    private Coroutine fadingCoroutine;


    private void Awake(){
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();

        Init();
    }

    private void Init(){
        if(state == FadeState.Inactive){
            canvasGroup.alpha = inactiveAlpha;
            image.enabled = false;
        }else if(state == FadeState.Active){
            canvasGroup.alpha = activeAlpha;
            image.enabled = true;
        }
    }

    private void OnEnable(){
        this.Register<FadeInEvent>();
        this.Register<FadeOutEvent>();
        this.Register<FadeStopEvent>();
    }

    private void OnDisable(){
        this.Remove<FadeInEvent>();
        this.Remove<FadeOutEvent>();
        this.Remove<FadeStopEvent>();
    }


    private void StartFading(float initAlpha, float endAlpha, float duration, TweenType tweenType, int id = 0, bool isIgnoreTimescale = true){
        if(this.id != id) return;
        if(fadingCoroutine != null) StopCoroutine(fadingCoroutine);
        fadingCoroutine = StartCoroutine(FadingCoroutine(initAlpha, endAlpha, duration, tweenType, id, isIgnoreTimescale));
    }

    private IEnumerator FadingCoroutine(float initAlpha, float endAlpha, float duration, TweenType tweenType, int id = 0, bool isIgnoreTimescale = true){
        yield return null;
        yield return null;

        EnableFader();

        float timer = 0;
        while(timer < duration){
            canvasGroup.alpha = Tween.DoTween(timer, 0, duration, initAlpha, endAlpha, tweenType);
            yield return null;
            timer += isIgnoreTimescale ? Time.unscaledDeltaTime : Time.deltaTime;
        }
        canvasGroup.alpha = endAlpha;

        DisableFader();
    }


    private void DisableFader(){
        image.enabled = false;
        if(useBlockRaycasts){
            canvasGroup.blocksRaycasts = false;
        }
    }

    private void EnableFader(){
        image.enabled = true;
        if(useBlockRaycasts){
            canvasGroup.blocksRaycasts = true;
        }
    }


#region Button
    protected virtual void FadeInSecond(){
        FadeInEvent.Invoke(1, new TweenType(Tween.TweenCurve.Linear), id);
    }

    protected virtual void FadeOutSecond(){
        FadeOutEvent.Invoke(1, new TweenType(Tween.TweenCurve.Linear), id);
    }

    protected virtual void DefaultFade(){
        if(state == FadeState.Active){
            FadeOutEvent.Invoke(defaultDuration, defaultTweenType, id, isIgnoreTimescale);
        }else if(state == FadeState.Inactive){
            FadeInEvent.Invoke(defaultDuration, defaultTweenType, id, isIgnoreTimescale);
        }
    }

    protected virtual void ResetFader(){
        canvasGroup.alpha = inactiveAlpha;
    }

    private void StartFader(){
        StartFading(activeAlpha, inactiveAlpha, defaultDuration, defaultTweenType, id, isIgnoreTimescale);
    }

#endregion


#region Event
    public void Invoke(FadeInEvent e){
        StartFading(activeAlpha, inactiveAlpha, e.Duration, e.TweenType, e.ID, e.IsIgnoreTimescale);
    }

    public void Invoke(FadeOutEvent e){
        StartFading(inactiveAlpha, activeAlpha, e.Duration, e.TweenType, e.ID, e.IsIgnoreTimescale);
    }

    public void Invoke(FadeStopEvent e){
        if(this.id == e.ID){
            StopCoroutine(fadingCoroutine);
        }
    }

#endregion


}
