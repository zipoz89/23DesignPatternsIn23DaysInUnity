using UnityEngine;

[System.Serializable]
public abstract class Enemy2 : MonoBehaviour {
    [SerializeField] protected MovingDirection direction = MovingDirection.Rigt;
    [SerializeField] private float speed = 1;
    [SerializeField] protected Rigidbody2D rigidbody2D;
    [SerializeField] protected float jumpVelocity;

    private void Awake() {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    protected void Move(){
        Vector3 dirVec = direction == MovingDirection.Rigt ? Vector3.right : Vector3.left;
        this.transform.position += dirVec * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "ReverseTrigger" || collision.tag == "Enemy") {
            direction = direction == MovingDirection.Rigt ? MovingDirection.Left : MovingDirection.Rigt;
        }
    }


    public void TemplateJump() {
        Jump();
    }

    protected abstract void Jump();
}
