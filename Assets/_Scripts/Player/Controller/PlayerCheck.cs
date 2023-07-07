using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundSize;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGround => Physics2D.OverlapBox(groundCheck.position, groundSize, 0, groundLayer);

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheck.position, groundSize);
    }
}
