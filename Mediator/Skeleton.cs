using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed = 4f;


    private void Start() {
        animator = this.GetComponent<Animator>();
    }
    public void Attack() {
        animator.SetTrigger("Attack");
    }

    public void Move(MovingDirection direction) {
        if (!animator.GetBool("IsMoving")) animator.SetBool("IsMoving",true);
        if (!(direction == MovingDirection.Rigt)) transform.rotation = new Quaternion(0,-180f,0,0);
        else transform.rotation = new Quaternion(0, 0, 0, 0);
        Vector3 dirVec = direction == MovingDirection.Rigt ? Vector3.right : Vector3.left;
        this.transform.position += dirVec * speed * Time.deltaTime;
    }

    public void StopMovement() {
        animator.SetBool("IsMoving", false);
    }
}
