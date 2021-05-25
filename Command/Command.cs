using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
    public abstract void Undo();
}

public class MoveCommand : Command {

    RoguelikePlayer objectToMove;
    Vector2Int moveDir;

    public MoveCommand(RoguelikePlayer objectToMove, Vector2Int moveDir) {
        this.objectToMove = objectToMove;
        this.moveDir = moveDir;
    }

    public override void Execute() {
        objectToMove.setNewPosition(moveDir);
    }

    public override void Undo() {
        objectToMove.setNewPosition(-moveDir);
    }
}