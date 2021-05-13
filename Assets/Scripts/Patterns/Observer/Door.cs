using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Observer
{
    [SerializeField] private bool isActive = false;
    Animator animator = null;
    [SerializeField] private TriggerBox trigger = null;

    private void Start() {
        animator = this.GetComponent<Animator>();
        trigger.RegisterObserver(this);
    }

    public override void OnNotify(object value, NotificationType type) {
        if(type == NotificationType.TriggerDoorlikeObject)
        if (isActive) {
            if ((string)value == "open") {

                if (!animator.GetBool("isDoorOpen")) {
                    animator.SetBool("isDoorOpen", true);
                }
            }
            else if ((string)value == "close") {

                if (animator.GetBool("isDoorOpen")) {
                    animator.SetBool("isDoorOpen", false);
                }

            }
        }
    }
}
