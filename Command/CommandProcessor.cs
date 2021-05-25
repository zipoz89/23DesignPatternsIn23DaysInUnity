using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> commandsList = new List<Command>();
    private int currentCommandIndex;

    public void ExecuteCommand(Command command) {
        commandsList.Add(command);
        command.Execute();
        currentCommandIndex = commandsList.Count - 1;
        //might be better design if i delete commands that are to old but w/e
    }

    public void Undo() {
        if (currentCommandIndex < 0) return;
        if (commandsList.Count == 0) return;

        commandsList[currentCommandIndex].Undo();
        commandsList.RemoveAt(currentCommandIndex);
        currentCommandIndex--;
    }
}
