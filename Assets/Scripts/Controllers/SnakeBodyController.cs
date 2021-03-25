using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    GameObject snakeHead;
    public int bodyPosition;

    private void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (LevelManager.Instance.IsGameOver()) {
            return;
        }

        float currentSpeed = snakeHead.GetComponent<SnakeHeadController>().speed;
        int commandOffset = Mathf.FloorToInt(300 / currentSpeed);

        MoveCommand moveCommand = (MoveCommand) CommandManager.Instance.GetCommand(bodyPosition * commandOffset);
        if (moveCommand != null) {
            transform.position = moveCommand._position;
            transform.Translate(moveCommand._direction * Time.deltaTime * moveCommand._speed);
        }
    }
}
