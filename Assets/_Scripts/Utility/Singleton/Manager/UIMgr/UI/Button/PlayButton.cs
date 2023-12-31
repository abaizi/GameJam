using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : LoadSceneButton, IPointerEnterHandler, IPointerExitHandler
{
    private Image _mask;
    private CanvasGroup _canvasGroup;


    protected override void Awake(){
        base.Awake();
        _sceneName = SceneMgr.PlaySceneName;

        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    public override void OnClick(){
        base.OnClick();
    }

    public void OnPointerEnter(PointerEventData eventData){
        StartCoroutine(_canvasGroup.FadeInCoroutine(0.2f));
    }

    public void OnPointerExit(PointerEventData eventData){
       StartCoroutine(_canvasGroup.FadeOutCoroutine(0.2f));
    }
}
