using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    public int bodyPosition;
    int commandOffset = 100;

    // Update is called once per frame
    void Update()
    {
        MoveCommand moveCommand = (MoveCommand) CommandManager.Instance.GetCommand(bodyPosition * commandOffset);
        if (moveCommand != null) {
            Debug.Log(moveCommand._position);
            transform.position = moveCommand._position;
            transform.Translate(moveCommand._direction * Time.deltaTime * moveCommand._speed);
        }
    }
}
