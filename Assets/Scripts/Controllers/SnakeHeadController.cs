using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction = Vector3.right;
    ICommand command;
    int bodySize = 0;
    [SerializeField] GameObject snakeBodyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.back) {
            direction = Vector3.forward;
        } else if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right) {
            direction = Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.forward) {
            direction = Vector3.back;
        } else if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left) {
            direction = Vector3.right;
        }

        Debug.Log("head: " +transform.position);

        command = new MoveCommand(transform, direction, speed);
        command.Execute();
        CommandManager.Instance.AddCommand(command);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) {
            //gameover
        } else if (other.CompareTag("Apple")) {
            other.gameObject.GetComponent<AppleController>().MoveApple();

            bodySize++;
            var snakeBody = Instantiate(snakeBodyPrefab);
            snakeBody.GetComponent<SnakeBodyController>().bodyPosition = bodySize;
        }
    }
}
