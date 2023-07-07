using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenDefinition
{
    public static float Linear(float x){
        return x;
    }


    public static float EaseInCubic(float x){
        return x * x * x;
    }
    public static float EaseOutCubic(float x){
        return 1 - Mathf.Pow(x, 3);
    }
    public static float EaseInOutCubic(float x){
        return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }


    public static float EaseInQuad(float x){
        return x * x;
    }
    public static float EaseOutQuad(float x){
        return 1 - (1 - x) * (1 - x);
    }
    public static float EaseInOutQuad(float x){
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }
}
