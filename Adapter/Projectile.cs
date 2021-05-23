using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(this);
    }
}
