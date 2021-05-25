using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguelikePlayer : MonoBehaviour
{
    public Vector2Int currentPositionOnMap = new Vector2Int(0, 0);
    public float nextGridDistanceToMove = 2;
    public Transform firstGridCell;
    [SerializeField] private float speed=10;
    Animator animator;
    private void Start() {
        animator = this.GetComponent<Animator>();
    }

    public void setNewPosition(Vector2Int newPos) {
        currentPositionOnMap += newPos; 
        MovePlayerObject();


    }

    public void MovePlayerObject() {
        StopAllCoroutines();
        //this.transform.position = new Vector3(currentPositionOnMap.x * nextGridDistanceToMove, currentPositionOnMap.y * nextGridDistanceToMove, -9) + firstGridCell.position;
        Vector3 newPosition = new Vector3(currentPositionOnMap.x * nextGridDistanceToMove, currentPositionOnMap.y * nextGridDistanceToMove, -9)+firstGridCell.position;
        animator.Play("Idle");
        animator.SetTrigger("Move");

        StartCoroutine(SmoothMove(newPosition));
    }
    IEnumerator SmoothMove(Vector3 newPosition) {
        float timeElapsed = 0;
        float timeLimit = 0.5f;
        while (timeElapsed < timeLimit) {
            timeElapsed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(this.transform.position, newPosition, timeElapsed/ timeLimit * speed);
            yield return null;
        }
        yield return null;

    }
}
