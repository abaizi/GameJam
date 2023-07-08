using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform background, middle, foreground,player;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + distance;
        background.position = transform.position / 4;
        middle.position = transform.position / 3;
        foreground.position = transform.position / 2;
    }
}
