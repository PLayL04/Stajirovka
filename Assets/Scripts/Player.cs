using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Look At Target System")]
    [SerializeField]
    private Camera mainCamera;

    [Header("Shooting System")]
    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private Transform shootingPoint;

    private MovementSystem movementSystem;
    private LookAtTargetSystem lookAtTargetSystem;
    private ShootingSystem shootingSystem;

    private void Awake()
    {
        movementSystem = new MovementSystem(transform, speed);
        lookAtTargetSystem = new LookAtTargetSystem(transform);
        shootingSystem = new ShootingSystem(projectilePrefab, shootingPoint);
    }

    private void Update()
    {
        Vector2 movementDirection = Vector2.zero;

        // Старая система ввода

        if (Input.GetKey(KeyCode.W))
            movementDirection += Vector2.up;

        if (Input.GetKey(KeyCode.S))
            movementDirection += Vector2.down;

        if (Input.GetKey(KeyCode.D))
            movementDirection += Vector2.right;

        if (Input.GetKey(KeyCode.A))
            movementDirection += Vector2.left;

        if (Input.GetMouseButtonDown(0))
        {
            shootingSystem.Shoot();
        }

        movementSystem.Move(movementDirection);

        Vector3 cursorWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        lookAtTargetSystem.LookAt(cursorWorldPosition);
    }
}
