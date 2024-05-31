using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Area Handlers")]
    [SerializeField]
    private TriggerHandler attackAreaHandler;

    private void Awake()
    {
        attackAreaHandler.TriggerEntered += OnAttackAreaTriggerEntered;
    }

    public void OnDestroy()
    {
        attackAreaHandler.TriggerEntered -= OnAttackAreaTriggerEntered;
    }

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnAttackAreaTriggerEntered(Collider2D other)
    {
        if (!other.TryGetComponent(out Enemy _))
            return;

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
