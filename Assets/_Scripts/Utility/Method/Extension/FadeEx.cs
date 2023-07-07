using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class FadeEx
{

#region CanvasGroup
    public static IEnumerator FadeCoroutine(this CanvasGroup canvasGroup, float targetAlpha, float duration){
        float timer = 0;
        while(timer < duration){
            canvasGroup.alpha = Mathf.SmoothStep(canvasGroup.alpha, targetAlpha, timer / duration);
            yield return null;
            timer += Time.deltaTime;
        }
        canvasGroup.alpha = targetAlpha;
    }

    public static IEnumerator FadeInCoroutine(this CanvasGroup canvasGroup, float duration){
        yield return FadeCoroutine(canvasGroup, 1, duration);
    }

    public static IEnumerator FadeOutCoroutine(this CanvasGroup canvasGroup, float duration){
        yield return FadeCoroutine(canvasGroup, 0, duration);
    }

#endregion

#region Image
    public static IEnumerator FadeCoroutine(this Image image, float targetAlpha, float duration){
        float timer = 0, initAlpha = image.color.a;
        while(timer < duration){
            Color color = new Color(image.color.r, image.color.g, image.color.b, Mathf.SmoothStep(initAlpha, targetAlpha, timer / duration));
            image.color = color;
            yield return null;
            timer += Time.deltaTime;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
    }

    public static IEnumerator FadeInCoroutine(this Image canvasGroup, float duration){
        yield return FadeCoroutine(canvasGroup, 1, duration);
    }

    public static IEnumerator FadeOutCoroutine(this Image canvasGroup, float duration){
        yield return FadeCoroutine(canvasGroup, 0, duration);
    }

#endregion

}
