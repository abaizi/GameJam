using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAim : MonoBehaviour, IEventListener<ShootEvent>
{
    private Rigidbody2D _rb;
    private PlayerCtrl _ctrl;

    private void Awake(){
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnEnable(){
        this.Register<ShootEvent>();
    }

    private void OnDisable(){
        this.Remove<ShootEvent>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            _ctrl = other.gameObject.GetComponent<PlayerCtrl>();
            _ctrl.HasAim = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            _ctrl.AimDir = (transform.position - _ctrl.transform.position).normalized;
            Debug.DrawRay(_ctrl.transform.position, _ctrl.AimDir, Color.blue, 10);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            _ctrl.HasAim = false;
        }
    }

    public void Invoke(ShootEvent e){
        _rb.velocity = Vector2.zero;
        _rb.AddForce(_ctrl.AimDir * e.ForceMul, ForceMode2D.Impulse);
    }
}
