using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private TweenType _tweenType;
    [SerializeField] private Transform _endPt;

    private float _initPosY;
    private float _endPosY;


    private void Awake(){
        _initPosY = transform.position.y;
        _endPosY = _endPt.position.y;
    }

    private void Start(){
        StartCoroutine(ScrollCoroutine());
    }



    private IEnumerator ScrollCoroutine(){
        FadeInEvent.Invoke(2.5f, _tweenType);
        yield return new WaitForSeconds(3);
        float timer = 0;
        while(timer < _duration){
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(_initPosY, _endPosY, timer / _duration), transform.position.z);
            yield return null;
            timer += Time.deltaTime;
        }
        StartCoroutine(FadeOutEvent.InvokeCoroutine(5, _tweenType));
    }

}
