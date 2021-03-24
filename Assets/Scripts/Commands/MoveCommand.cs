using UnityEngine;

public class MoveCommand : ICommand
{
    Transform _transform;
    Vector3 _direction;
    float _speed;

    public MoveCommand(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
    }

    public void Execute()
    {
        _transform.Translate(_direction * Time.deltaTime * _speed);
    }
}
