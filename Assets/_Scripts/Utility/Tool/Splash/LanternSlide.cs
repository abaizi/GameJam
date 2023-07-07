using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSlide : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private bool isChangeScene = true;
    [SerializeField] private string nextSceneName = "";


    [Header("Display")]
    [SerializeField] private float displayDuration = 2f;
    [SerializeField] private List<GameObject> displayObjs = new List<GameObject>();


    [Header("Fade")]
    [SerializeField] private int fadeID = 0;
    [SerializeField] private bool useFadeIn = true;
    [SerializeField] private bool useFadeOut = true;
    [SerializeField] private float fadeInDuration = 1;
    [SerializeField] private float fadeOutDuration = 1;
    [SerializeField] private TweenType tweenType;


    private WaitForSeconds waitForFadeIn;
    private WaitForSeconds waitForFadeOut;
    private WaitForSeconds waitForDisplay;


    private void Awake(){
        waitForFadeIn = new WaitForSeconds(fadeInDuration);
        waitForFadeOut = new WaitForSeconds(fadeOutDuration);
        waitForDisplay = new WaitForSeconds(displayDuration);
    }

    public void StartPlay(){
        StartCoroutine(PlayCoroutine());
    }

    private IEnumerator PlayCoroutine(){
        FadeOutEvent.Invoke(fadeOutDuration, tweenType, fadeID);
        yield return waitForFadeOut;

        foreach(GameObject gObj in displayObjs){
            gObj.SetActive(true);
            if(useFadeIn){
                FadeInEvent.Invoke(fadeInDuration, tweenType, fadeID);
                yield return waitForFadeIn;
            }

            yield return waitForDisplay;

            if(useFadeOut){
                FadeOutEvent.Invoke(fadeOutDuration, tweenType, fadeID);
                yield return waitForFadeOut;
            }
            gObj.SetActive(false);
        }

        if(isChangeScene){
            SceneMgr.LoadScene(nextSceneName, true);
        }else{
            FadeInEvent.Invoke(fadeInDuration, tweenType, fadeID);
        }
    }
}
