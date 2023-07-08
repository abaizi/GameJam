using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform _dirPt;
    [SerializeField] private float _fixedForce;
    [SerializeField] private float _impact;


    private Vector2 _fixedDir;


    public Rigidbody2D rb;
    public bool IsWater;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();

        _fixedDir = (_dirPt.position - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            rb.velocity = Vector2.zero;
            Vector2 dir = (transform.position - other.transform.position).normalized;
            rb.AddForce(dir * _impact + _fixedDir * _fixedForce);
        }
    }
}
