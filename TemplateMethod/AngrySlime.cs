using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrySlime : Enemy2 {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            TemplateJump();
        Move();
    }

    protected override void Jump() {
        StartCoroutine(AngryJump());
    }
    IEnumerator AngryJump() {
        rigidbody2D.velocity = Vector2.up * jumpVelocity;
        yield return new WaitForSeconds(0.5f);
        rigidbody2D.velocity += (direction == MovingDirection.Rigt ? Vector2.right : Vector2.left) * jumpVelocity*2;
    }
}
