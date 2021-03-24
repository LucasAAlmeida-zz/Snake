using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction = Vector3.right;
    ICommand command;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector3.forward;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector3.back;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector3.right;
        }

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
        }
    }
}
