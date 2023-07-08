using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _backGround;
    [SerializeField] private Transform _frontGround;
    [SerializeField] private Transform followPt;

    [SerializeField] private float _backGroundSpeedMul;
    [SerializeField] private float _frontGroundSpeedMul;

    private float _bgInitX;
    private float _fgInitX;

    private void Awake(){
        _bgInitX = _backGround.position.x;
        _fgInitX = _frontGround.position.x;
    }

    private void Update(){
        float bgOffset = followPt.position.x - _bgInitX;
        float fgOffset = followPt.position.x - _fgInitX;
        Debug.Log(bgOffset);

        _backGround.position = Vector3.right * bgOffset * _backGroundSpeedMul;
        _frontGround.position = Vector3.left * fgOffset * _frontGroundSpeedMul;
    }
}
