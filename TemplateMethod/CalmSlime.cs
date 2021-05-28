using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingDirection { 
    Left,
    Rigt
}


public class CalmSlime : Enemy2
{

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
            TemplateJump();
        Move(); 
    }
    protected override void Jump() {
        rigidbody2D.velocity = Vector2.up * jumpVelocity;
    }


}
