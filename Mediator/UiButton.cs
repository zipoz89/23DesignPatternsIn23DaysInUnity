using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler , IPointerUpHandler {
    enum ClickType {
        press,
        hold
    }

    Mediator mediator;
    public GameObject toGetMediatorFrom;
    [SerializeField] private ClickType type;
    [SerializeField] private MediatorEvents ev;
    [SerializeField] private MediatorEvents buttonUp;
    private bool isPressed = false;

    public void OnPointerClick(PointerEventData eventData) {
        if (type == ClickType.hold) return;
        mediator.Notify(this, ev);
    }
    public void OnPointerDown(PointerEventData eventData) {
        if (type == ClickType.press) return;
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (type == ClickType.press) return;
        mediator.Notify(this, buttonUp);
        isPressed = false;
    }

    private void Start() {
        mediator = toGetMediatorFrom.GetComponent<Mediator>();
    }


    void Update()
    {
        if(isPressed) mediator.Notify(this, ev);
    }
}
