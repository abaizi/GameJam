using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public static IEnumerator WaitForFrame(int count){
        while(count > 0){
            count--;
            yield return null;
        }
    }

    public static IEnumerator WaitForTime(float duration){
        for(float timer = 0; timer < duration; timer += Time.deltaTime){
            yield return null;
        }
    }

    public static IEnumerator WaitForUnscaled(float duration){
        for(float timer = 0; timer < duration; timer += Time.unscaledDeltaTime){
            yield return null;
        }
    }
}
