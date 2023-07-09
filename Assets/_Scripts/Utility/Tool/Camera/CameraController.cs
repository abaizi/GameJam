using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform background, foreground, player;
    private Vector3 distance;
    private Vector3 temp;
    void Start(){
        distance = transform.position - player.position;
    }

    void Update(){
        transform.position = player.position + distance;
        temp = transform.position / 4;
        background.position = new Vector3(temp.x,background.position.y,background.position.z);
        temp = transform.position / 2;
        foreground.position = new Vector3(temp.x,foreground.position.y,foreground.position.z);
    }
}
