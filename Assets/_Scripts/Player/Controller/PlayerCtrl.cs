using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _decceleration;
    [SerializeField] private float _accePow;
    [SerializeField] private float _friction;

    [Space(10)] [Header("Jump")] 
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _fallGravityMul;


    private Rigidbody2D _rb;
    private GroundCheck _check;
    private SpriteRenderer _spriteRenderer;

    private float _lastJumpMul = 1;
    private float _lastMoveMul = 1;

    public float LastJumpMul => _lastJumpMul;
    public float LastMoveMul => _lastMoveMul;

    public float JumpMul {get; set;} = 1;
    public float MoveMul {get; set;} = 1;


    public bool IsFall => !_check.IsGround && _rb.velocity.y < 0;
    public bool HasDoubleJump {get; set;} = true;
    public bool CanJump {get; set;} = true;
    public bool HasDash {get; set;} = true;
    public bool DashCDOver {get; private set;} = true;
    public bool CanDash => HasDash && InputMgr.Inst.IsDash && DashCDOver;
    public float Dir => -transform.localScale.x;


    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();
        _check = GetComponent<GroundCheck>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        InputMgr.Inst.EnablePlayerInput();
    }


    public void MoveX(){
        if(InputMgr.Inst.MoveInput.x != 0) transform.localScale = new Vector3(-InputMgr.Inst.MoveInput.x, transform.localScale.y, transform.localScale.z);

        float speedDif = InputMgr.Inst.MoveInput.x * _moveSpeed * MoveMul - _rb.velocity.x;
        float acceValue = InputMgr.Inst.IsMove ? _acceleration : _decceleration;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * acceValue, _accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    public void MoveX(float speedMul = 1, float acceMul = 1){
        if(InputMgr.Inst.IsMove) transform.localScale = new Vector3(-InputMgr.Inst.MoveInput.x, transform.localScale.y, transform.localScale.z);
        float speedDif = InputMgr.Inst.MoveInput.x * _moveSpeed * MoveMul * speedMul - _rb.velocity.x;
        float acceValue = InputMgr.Inst.IsMove ? _acceleration * acceMul : _decceleration;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * acceValue, _accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    
    public void DisableMove(){
        RecordMul();
        SetVelocityX(0);
        SetVelocityY(0);
        SetGravity(0);
        MoveMul = 0;
        JumpMul = 0;
    }

    public void RecordMul(){
        _lastMoveMul = MoveMul;
        _lastJumpMul = JumpMul;
    }

    public void ResetMul(){
        MoveMul = _lastMoveMul;
        JumpMul = _lastJumpMul;
        SetGravity();
    }


    public void AddFriction(){
        float fric = Mathf.Min(Mathf.Abs(_rb.velocity.x), Mathf.Abs(_friction)) * Mathf.Sign(_rb.velocity.x);
        _rb.AddForce(Vector2.right * -fric, ForceMode2D.Impulse);
    }

    public void Jump(float jumpForce){
        SetVelocityY(0);
        _rb.AddForce(Vector2.up * jumpForce * JumpMul, ForceMode2D.Impulse);
    }

    public void SetVelocityY(float velocity){
        _rb.velocity = new Vector2(_rb.velocity.x, velocity);
    }

    public void SetGravity(float mul = 1){
        _rb.gravityScale = _gravityScale * mul;
    }

    public void SetFallGravity(){
        _rb.gravityScale = _gravityScale * _fallGravityMul;
    }

    public void SetVelocityX(float velocity){
        _rb.velocity = Vector2.right * velocity;
    }

    public void StartDashTimer(float duration){
        StopCoroutine(DashTimer(duration));
        StartCoroutine(DashTimer(duration));
    }

    private IEnumerator DashTimer(float duration){
        DashCDOver = false;
        yield return Timer.WaitForTime(duration);
        DashCDOver = true;
    }

    public void Die(){
        Debug.Log("Die");
    }
}
