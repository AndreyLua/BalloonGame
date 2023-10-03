using UnityEngine;

internal struct MoveableComponent
{
    public Vector2 Direction;
    public float Speed;

    public MoveableComponent(Vector2 direction, float speed)
    {
        Direction = direction.normalized;
        Speed = speed;
    }
}
