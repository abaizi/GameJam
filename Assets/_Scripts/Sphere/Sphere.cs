using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform _dirPt;
    [SerializeField] private float _fixedForce;
    [SerializeField] private float _impact;


    private Rigidbody2D _rb;
    private Vector2 _fixedDir;


    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();

        _fixedDir = (_dirPt.position - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            _rb.velocity = Vector2.zero;
            Vector2 dir = (transform.position - other.transform.position).normalized;
            _rb.AddForce(dir * _impact + _fixedDir * _fixedForce);
        }
    }

    // private void OnCollisionStay2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Player")){
    //         _rb.velocity = Vector2.zero;
    //         _rb.AddForce(_moveDir * _force);
    //     }
    // }
}
