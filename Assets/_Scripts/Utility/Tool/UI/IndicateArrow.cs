using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateArrow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform arrow;
    [SerializeField] private int displayeDistance = 1;

    [SerializeField] private int scaleDistance = 100;

    [SerializeField] private float minScaleSize;
    [SerializeField] private float maxScaleSize;

    private Vector3 dir;

    private void Update()
    {
        dir = transform.position - player.position;
        arrow.transform.position = dir.normalized * displayeDistance  + player.transform.position;
        arrow.transform.up = dir.normalized;

        if (dir.sqrMagnitude <= scaleDistance)
        {
            float scaleSize = (scaleDistance - dir.sqrMagnitude) / scaleDistance;
            scaleSize = Mathf.Clamp(scaleSize, minScaleSize, maxScaleSize);
            arrow.transform.localScale = new Vector3(scaleSize,scaleSize,1);
        }
    }
}
