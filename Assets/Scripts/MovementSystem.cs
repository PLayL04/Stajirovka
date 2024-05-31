using UnityEngine;

public class MovementSystem
{
    private readonly Transform transform;
    private readonly float speed;

    public MovementSystem(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }

    public void Move(Vector2 movementDirection)
    {
        float multiplier = Time.deltaTime * speed;
        Vector2 direction = movementDirection.normalized * multiplier;
        transform.Translate(direction, Space.World);
    }
}
