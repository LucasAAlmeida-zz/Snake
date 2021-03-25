using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    public float speed;
    Vector3 direction = Vector3.right;
    ICommand command;
    int bodySize = 0;
    [SerializeField] GameObject snakeBodyPrefab;

    private void Update()
    {
        if (LevelManager.Instance.IsGameOver()) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.back) {
            direction = Vector3.forward;
        } else if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right) {
            direction = Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.forward) {
            direction = Vector3.back;
        } else if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left) {
            direction = Vector3.right;
        }

        command = new MoveCommand(transform, direction, speed);
        command.Execute();
        CommandManager.Instance.AddCommand(command);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeBody") && other.gameObject.GetComponent<SnakeBodyController>().bodyPosition != 1) {
            GameOver();
        } else if (other.CompareTag("Apple")) {
            var apple = other.gameObject.GetComponent<AppleController>();
            apple.PlaySound();
            apple.MoveApple();

            bodySize++;
            var snakeBody = Instantiate(snakeBodyPrefab);
            snakeBody.GetComponent<SnakeBodyController>().bodyPosition = bodySize;
            
            LevelManager.Instance.AddScore(50);
            speed += 0.2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        LevelManager.Instance.GameOver();
    }
}
