using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Ground
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float _sphereDrag = 5;

    private Animator _animator;
    private string path = "Prefabs/Effect";


    protected override void Awake(){
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    protected override void OnPlayerTriggerEnter(Collider2D other){
        base.OnPlayerTriggerEnter(other);
        AudioMgr.Inst.PlaySFX(clip);

        _ctrl.IsWater = true;
        _data.fsm.Switch(typeof(PlayerState_IdleWater));
        
        Vector3 pos = _ctrl.transform.position;
        GameObject effect = Instantiate<GameObject>(Resources.Load<GameObject>(path), pos, Quaternion.identity, transform);
        effect.GetComponent<Animator>().Play("FallWater");
        Destroy(effect, 0.3f);
    }

    protected override void OnPlayerTriggerStay(Collider2D other){
        base.OnPlayerTriggerStay(other);
    }

    protected override void OnPlayerTriggerExit(Collider2D other){
        base.OnPlayerTriggerExit(other);
        _ctrl.IsWater = false;

        Vector3 pos = _ctrl.transform.position;
        GameObject effect = Instantiate<GameObject>(Resources.Load<GameObject>(path), pos, Quaternion.identity, transform);
        effect.GetComponent<Animator>().Play("UpWater");
        Destroy(effect, 0.5f);
    }


    protected override void OnSphereTriggerEnter(Collider2D other){
        base.OnSphereTriggerEnter(other);
        _rbSphere.drag = _sphereDrag;
    }

    protected override void OnSphereTriggerStay(Collider2D other){
        base.OnSphereTriggerStay(other);
    }

    protected override void OnSphereTriggerExit(Collider2D other){
        base.OnSphereTriggerExit(other);
        _rbSphere.drag = 0;
    }
}
