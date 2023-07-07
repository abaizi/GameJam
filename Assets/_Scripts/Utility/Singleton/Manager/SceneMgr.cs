using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneMgr : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private Text loadingText;
    [SerializeField] private Image progressBarImage;
    [SerializeField] private CanvasGroup loadingProgressBar;
    [SerializeField] private CanvasGroup loadingAnim;
    [SerializeField] private CanvasGroup completeAnim;


    [Header("Time")]
    [SerializeField] private float progressBarSpeed = 2f;


    [Header("Fade")]
    [SerializeField] private float fadeInDuration = 1;
    [SerializeField] private float fadeOutDuration = 1;
    [SerializeField] private TweenType tweenType;

    public static string LoadingSceneName = "LoadingScene";
    public static string StartSceneName = "StartScene";
    public static string PlaySceneName = "PlayScene";

    private AsyncOperation asyncOperation;
    private WaitForSeconds waitForFadeIn;
    private WaitForSeconds waitForFadeOut;
    private static string _sceneName;

    private float ProgressRate {get => progressBarImage.fillAmount; set => progressBarImage.fillAmount = value;}


    private void Awake(){
        waitForFadeIn = new WaitForSeconds(fadeInDuration);
        waitForFadeOut = new WaitForSeconds(fadeOutDuration);

        if(SceneManager.GetActiveScene().name == LoadingSceneName){
            LoadSceneAsync();
        }
    }


    public static void LoadScene(string sceneName, bool isAsync = false){
        if(sceneName == null) return;

        Application.backgroundLoadingPriority = ThreadPriority.High;
        LoadStartEvent.Invoke(sceneName);

        if(isAsync){
            _sceneName = sceneName;
            SceneManager.LoadScene(LoadingSceneName);
        }else{
            SceneManager.LoadScene(sceneName);
        }
    }


    private void LoadSceneAsync(){
        StartCoroutine(LoadSceneCoroutine(_sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName){
        LoadingSetup();

        FadeInEvent.Invoke(fadeInDuration, tweenType);
        yield return waitForFadeIn;

        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while(asyncOperation.progress < 0.9f - Mathf.Epsilon){
            ProgressRate = Mathf.MoveTowards(ProgressRate, asyncOperation.progress, progressBarSpeed * Time.deltaTime);
            yield return null;
        }
        while(ProgressRate < 1){
            ProgressRate = Mathf.MoveTowards(ProgressRate, 1, progressBarSpeed * Time.deltaTime);
            yield return null;
        }
        ProgressRate = 1;

        LoadingComplete(sceneName);
    }

    private void LoadingSetup(){
        completeAnim.alpha = 0;
        ProgressRate = 0;
    }

    private void LoadingComplete(string sceneName){
        StartCoroutine(CompleteCoroutine(sceneName));
    }

    private IEnumerator CompleteCoroutine(string sceneName){
        StartCoroutine(loadingProgressBar.FadeOutCoroutine(0.2f));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(loadingAnim.FadeOutCoroutine(0.5f));
        StartCoroutine(completeAnim.FadeInCoroutine(1f));
        yield return new WaitForSeconds(1);

        FadeOutEvent.Invoke(fadeOutDuration, tweenType);
        yield return waitForFadeOut;

        asyncOperation.allowSceneActivation = true;
        LoadCompleteEvent.Invoke(sceneName);
    }
}

