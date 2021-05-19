using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2d : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [Range(0, .3f)] [SerializeField] private float smoothnigValue = .05f;
    public bool isRunning = false;
    public float moveSpeed = 10;

    private Vector3 idkWhatItDoesButItMustBeZeroToWork = Vector3.zero;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (isRunning)
            animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0) {
            isRunning = true;
            if (horizontalAxis < 0)
                this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            else this.transform.localRotation = Quaternion.Euler(0,0, 0);
            MoveCharacter(horizontalAxis);
        }
        else isRunning = false;
    }

    private void MoveCharacter(float horizontalAxis) {
        Vector3 targetVeolicty = new Vector3(this.transform.position.x+ moveSpeed * horizontalAxis * Time.deltaTime, this.transform.position.y);
        this.transform.position = targetVeolicty;
    }
}
