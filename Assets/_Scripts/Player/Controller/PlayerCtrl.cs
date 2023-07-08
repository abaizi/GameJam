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

    [Space(10)] [Header("Water")]
    [SerializeField] private float _waterSpeedXMul = 0.3f;
    [SerializeField] private float _waterSpeedYMul = 0.2f;
    [SerializeField] private float _waterFallSpeed = 1;


    private Rigidbody2D _rb;
    private Collider2D _collider;
    private GroundCheck _check;

    private float _acceValue => InputMgr.Inst.IsMove ? _acceleration : _decceleration;

    private float _lastJumpMul = 1;
    private float _lastMoveMul = 1;

    public float JumpMul {get; set;} = 1;
    public float MoveMul {get; set;} = 1;

    public bool IsFallWater => Mathf.Approximately(_rb.velocity.y, 0);
    public bool IsFall => !_check.IsGround && _rb.velocity.y < 0;

    public bool HasDoubleJump {get; set;} = true;

    public bool HasDash {get; set;} = true;
    public bool DashCDOver {get; private set;} = true;
    public bool CanDash => HasDash && InputMgr.Inst.IsDash && DashCDOver;

    public bool HasAim {get; set;} = false;
    public bool CanAim => HasAim && InputMgr.Inst.IsAim;
    public Vector2 AimDir {get; set;}

    public bool IsWater {get; set;}

    

    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();
        _check = GetComponent<GroundCheck>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start(){
        InputMgr.Inst.EnablePlayerInput();

        var data = SaveMgr.Load<SaveJson, PlayerSaveData>(PlayerSaveData.SaveFileName);
        transform.position = data.position;
    }


    [InspectButton("Test")]
    public bool b;
    private void Test(){
        EventMgr.Test();
    }


    public void PlayerMoveX(){
        if(InputMgr.Inst.MoveInput.x != 0) transform.localScale = new Vector3(InputMgr.Inst.MoveInput.x * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        MoveX();
    }

    public void PlayerMoveX(float speedMul = 1, float acceMul = 1){
        if(InputMgr.Inst.MoveInput.x != 0) transform.localScale = new Vector3(InputMgr.Inst.MoveInput.x, transform.localScale.y, transform.localScale.z);
        
        float speedDif = InputMgr.Inst.MoveInput.x * _moveSpeed * MoveMul * speedMul - _rb.velocity.x;
        float acceValue = InputMgr.Inst.IsMove ? _acceleration * acceMul : _decceleration;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * _acceValue, _accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    public void MoveInWater(){
        if(InputMgr.Inst.MoveInput.x != 0) transform.localScale = new Vector3(InputMgr.Inst.MoveInput.x, transform.localScale.y, transform.localScale.z);
        
        MoveX(_waterSpeedXMul);
        if(InputMgr.Inst.MoveInput.y == 0){
            SetVelocityY(-_waterFallSpeed);
            return;
        }
        MoveY(_waterSpeedYMul);
    }

    public void JumpInWater(){
        if(InputMgr.Inst.MoveInput.x != 0) transform.localScale = new Vector3(InputMgr.Inst.MoveInput.x, transform.localScale.y, transform.localScale.z);

        MoveX(_waterSpeedXMul);
        MoveY(_waterSpeedYMul);
    }


    private void MoveX(float speedMul = 1){
        float speedDif = InputMgr.Inst.MoveInput.x * _moveSpeed * MoveMul * speedMul - _rb.velocity.x;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * _acceValue, _accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.right * force);
    }

    private void MoveY(float speedMul = 1){
        float speedDif = InputMgr.Inst.MoveInput.y * _moveSpeed * MoveMul * speedMul - _rb.velocity.y;
        float force = Mathf.Pow(Mathf.Abs(speedDif) * _acceValue, _accePow) * Mathf.Sign(speedDif);
        _rb.AddForce(Vector2.up * force);
    }


    public void DisableMove(){
        SetVelocityX(0);
        SetVelocityY(0);
        SetGravity(0);
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

    public void AddForce(Vector2 force, ForceMode2D mode){
        _rb.AddForce(force, mode);
    }

    public void AddShootForce(float forceMul){
        _rb.AddForce(-AimDir * forceMul, ForceMode2D.Impulse);
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
        DisableMove();

        _collider.enabled = false;
    }

    public void Revive(){
        _collider.enabled = true;
    }
}
