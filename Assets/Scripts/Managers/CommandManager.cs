using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public static CommandManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }
}
