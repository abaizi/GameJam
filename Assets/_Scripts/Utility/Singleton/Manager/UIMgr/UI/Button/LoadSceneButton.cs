using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : ButtonBase
{
    [Header("Load")]
    [SerializeField] protected string _sceneName = "";
    [SerializeField] private bool _isAsync = false;

    [Header("Fade")]
    [SerializeField] private bool _isFadeOut = true;
    [SerializeField] private float _fadeOutDuration = 1;
    [SerializeField] private TweenType _tweenType;


    public override void OnClick(){
        if(_isFadeOut){
            StartCoroutine(LoadSceneCoroutine(_isAsync));
        }else{
            SceneMgr.LoadScene(_sceneName, true);
        }
    }

    private IEnumerator LoadSceneCoroutine(bool isAsync){
        yield return FadeOutEvent.InvokeCoroutine(_fadeOutDuration, _tweenType);
        SceneMgr.LoadScene(_sceneName, isAsync);
    }
}
