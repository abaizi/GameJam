using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform dirPt;
    [SerializeField] private float force;


    private Rigidbody2D _rb;
    private Vector2 moveDir;

    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();

        moveDir = (dirPt.position - transform.position).normalized;
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            _rb.velocity = Vector2.zero;
            _rb.AddForce(moveDir * force);
        }
    }
}
