using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerObserer : MonoBehaviour
{
    [SerializeField] private Animator[] triggers = null;
    [SerializeField] private bool isActive = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (isActive) {
                foreach(Animator triger in triggers)
                if (!triger.GetBool("isDoorOpen")) {
                        triger.SetBool("isDoorOpen", true);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (isActive) {
                foreach (Animator triger in triggers)
                    if (triger.GetBool("isDoorOpen")) {
                        triger.SetBool("isDoorOpen", false);
                    }

            }
        }
    }


}
