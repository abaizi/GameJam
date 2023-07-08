using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform _dirPt;
    [SerializeField] private float _force;

    private void Start(){

    }
    private Rigidbody2D _rb;
    private Vector2 _moveDir;


    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();

        _moveDir = (_dirPt.position - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            _rb.velocity = Vector2.zero;
            _rb.AddForce(_moveDir * _force);
        }
    }

    // private void OnCollisionStay2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Player")){
    //         _rb.velocity = Vector2.zero;
    //         _rb.AddForce(_moveDir * _force);
    //     }
    // }
}
