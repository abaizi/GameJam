using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    [SerializeField] private float accePow;
    [SerializeField] private float friction;

    [Space(10)] [Header("Jump")] 
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityMul;



    private Rigidbody2D _rb;
    private PlayerCheck _check;

    public bool IsFall => !_check.IsGround && _rb.velocity.y < 0;
    public bool HasDoubleJump {get; set;}
    public bool HasDash {get; set;}


    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();
        _check = GetComponent<PlayerCheck>();
    }

    private void Start(){
        InputMgr.Inst.EnablePlayerInput();
    }


    public void MoveX(){
        float speedDif = InputMgr.Inst.MoveInput.x * moveSpeed - _rb.velocity.x;
        float acceValue = InputMgr.Inst.IsMove ? acceleration : decceleration;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * acceValue, accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    public void MoveX(float speedMul = 1, float acceMul = 1){
        float speedDif = InputMgr.Inst.MoveInput.x * moveSpeed * speedMul - _rb.velocity.x;
        float acceValue = InputMgr.Inst.IsMove ? acceleration * acceMul : decceleration;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * acceValue, accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    public void AddFriction(){
        float fric = Mathf.Min(Mathf.Abs(_rb.velocity.x), Mathf.Abs(friction)) * Mathf.Sign(_rb.velocity.x);
        _rb.AddForce(Vector2.right * -fric, ForceMode2D.Impulse);
    }

    public void Jump(float jumpForce){
        SetSpeedY(0);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void SetSpeedY(float velocity){
        _rb.velocity = new Vector2(_rb.velocity.x, velocity);
    }

    public void SetGravity(float mul = 1){
        _rb.gravityScale = gravityScale * mul;
    }

    public void SetFallGravity(){
        _rb.gravityScale = gravityScale * fallGravityMul;
    }
}
