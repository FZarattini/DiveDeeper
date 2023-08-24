using UnityEngine;
using Sirenix.OdinInspector;

public class FollowTarget : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform followTarget;

    [SerializeField, Range(0, 10)] private float followDistance;
    [SerializeField, Range(0, 10)] private float followSpeed;

    private Vector2 directionToTarget;
    private float distanceToTarget;

    [SerializeField, ReadOnly] bool enableFollow = false;

    public bool FollowEnabled => enableFollow;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (!enableFollow) return;

        LookDirection();

        distanceToTarget = Vector2.Distance(followTarget.position, transform.position);

        if (distanceToTarget < followDistance)
            return;

        // Move the pet towards the target position
        transform.position = Vector2.MoveTowards(transform.position, followTarget.position, followSpeed * Time.deltaTime);
    }

    private void LookDirection()
    {
        directionToTarget = followTarget.position - transform.position;

        spriteRenderer.flipX = directionToTarget.x < 0;
    }

    public void EnableFollow(bool value)
    {
        enableFollow = value;
    }
}
