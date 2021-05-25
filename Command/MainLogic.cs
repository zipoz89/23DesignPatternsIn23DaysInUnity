using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    [SerializeField] private int xSize = 4;
    [SerializeField] private int ySize = 4;
    [SerializeField] private Transform firstGridCell;
    [SerializeField] private float nextGridDistance;
    [SerializeField] private RoguelikePlayer player;
    [SerializeField] private CommandProcessor commandProcessor;


    private void Start() {
        player.nextGridDistanceToMove = nextGridDistance;
        player.firstGridCell = firstGridCell;
        //^ this is stupid but i wanted to have all options to change in one place
        player.MovePlayerObject();
    }

    private void Update() {
        Vector2Int t = GetDirection();
        if (t != Vector2Int.zero) {
            if (player.currentPositionOnMap.x+t.x< xSize && player.currentPositionOnMap.x + t.x >= 0 && player.currentPositionOnMap.y + t.y >= 0 && player.currentPositionOnMap.y + t.y < ySize) { 
            var moveCommand = new MoveCommand(player, t);
            commandProcessor.ExecuteCommand(moveCommand);

            }
        }
        if (GetUndo()) {
            commandProcessor.Undo();
        }
    }

    public void BackPressed() {
        commandProcessor.Undo();
    }

    public Vector2Int GetDirection() {
        int x = 0;
        if (Input.GetKeyDown(KeyCode.D)) x = 1;
        if (Input.GetKeyDown(KeyCode.A)) x = -1;
        int y = 0;
        if (Input.GetKeyDown(KeyCode.W)) y = 1;
        if (Input.GetKeyDown(KeyCode.S)) y = -1;
        if (x != 0 || y != 0)
            return new Vector2Int(x, y);
        else return Vector2Int.zero;
    }

    public bool GetUndo() {
        return Input.GetKeyDown(KeyCode.Backspace);
    }
}
