using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform background, foreground, player;
    private Vector3 distance;
    void Start(){
        distance = transform.position - player.position;
    }

    void Update(){
        transform.position = player.position + distance;
        background.position = transform.position / 4;
        foreground.position = transform.position / 2;
    }
}
