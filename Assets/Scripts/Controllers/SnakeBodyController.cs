using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    public int bodyPosition;
    readonly int commandOffset = 150;

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.IsGameOver()) {
            return;
        }

        MoveCommand moveCommand = (MoveCommand) CommandManager.Instance.GetCommand(bodyPosition * commandOffset);
        if (moveCommand != null) {
            transform.position = moveCommand._position;
            transform.Translate(moveCommand._direction * Time.deltaTime * moveCommand._speed);
        }
    }
}
