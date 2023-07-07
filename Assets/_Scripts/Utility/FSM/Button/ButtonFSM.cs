using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class ButtonFSM : FSMBase, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private List<ButtonState> states = new List<ButtonState>();

    [Header("Binding")]
    [SerializeField] private UnityEvent ButtonClick;
    [SerializeField] private UnityEvent ButtonPressed;
    [SerializeField] private UnityEvent ButtonReleased;

    [Header("Opacity")]
    [SerializeField] private float idleOpacity;
    [SerializeField] private float enterOpacity;
    [SerializeField] private float pressedOpacity;

    private Animator _animator;
    private CanvasGroup _canvasGroup;



    private void Start(){
        SwitchOn(typeof(ButtonState_Idle));
    }

    protected override void Init(){
        _animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _data = new ButtonStateData(this, _animator, _canvasGroup);
    }



    public void OnPointerEnter(PointerEventData eventData){
        _canvasGroup.alpha = enterOpacity;
    }

    public void OnPointerExit(PointerEventData eventData){
        _canvasGroup.alpha = idleOpacity;
    }

    public void OnPointerDown(PointerEventData eventData){
        _canvasGroup.alpha = pressedOpacity;
        Switch(typeof(ButtonState_Click));
    }

    public void OnPointerUp(PointerEventData eventData){
        _canvasGroup.alpha = enterOpacity;
        Switch(typeof(ButtonState_Released));
    }
}
