using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : Subject
{
    private void OnTriggerEnter(Collider other) {
        Notify("open",NotificationType.TriggerDoorlikeObject);
    }

    private void OnTriggerExit(Collider other) {
        Notify("close", NotificationType.TriggerDoorlikeObject);
    }

}
