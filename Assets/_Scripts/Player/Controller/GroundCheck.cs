using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundSize;
    [SerializeField] private LayerMask _groundLayer;
    
    public bool IsGround => Physics2D.OverlapBox(_groundCheck.position, _groundSize, 0, _groundLayer);

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(_groundCheck.position, _groundSize);
    }
}
