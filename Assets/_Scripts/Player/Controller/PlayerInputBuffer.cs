using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInputBuffer : ScriptableObject
{
    [SerializeField] private float jumpBufferTime = 0.5f;
    private WaitForSeconds waitForJumpBuffer;
    public bool IsJumpBuffer {get; set;}

    private void Start(){
        waitForJumpBuffer = new WaitForSeconds(jumpBufferTime);
        Debug.Log(1);
    }

    private void OnEnable(){
        waitForJumpBuffer = new WaitForSeconds(jumpBufferTime);
    }

    public IEnumerator JumpBufferCoroutine(){
        IsJumpBuffer = true;
        yield return waitForJumpBuffer;
        IsJumpBuffer = false;
    }
}
