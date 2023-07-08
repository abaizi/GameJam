using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surf : MonoBehaviour
{
    private Rigidbody2D _targetRigid;
    [SerializeField] private string targetTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            print("SB");
            _targetRigid = other.GetComponent<Rigidbody2D>();
            _targetRigid.gravityScale = 0.001f;
            _targetRigid.velocity = Vector2.zero;

        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            print("SB");
            _targetRigid = other.GetComponent<Rigidbody2D>();
            _targetRigid.gravityScale = 1;

        }
    }
}
