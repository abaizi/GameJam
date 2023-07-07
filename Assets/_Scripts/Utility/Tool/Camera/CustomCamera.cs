using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private Transform _followPt;
    [SerializeField] private Vector2 _damping;

    private Vector3 _cameraPos {get => Camera.main.transform.position; set => Camera.main.transform.position = value;}

    private void Update(){
        _cameraPos = new Vector3(Mathf.Lerp(_followPt.position.x, _cameraPos.x, _damping.x),
         Mathf.Lerp(_followPt.position.y, _cameraPos.y, _damping.y), _cameraPos.z);
    }

    
}
