using UnityEngine;

public class RatController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [SerializeField, Range(0, 10)] private float followDistance;
    [SerializeField, Range(0, 10)] private float followSpeed;

    private float distanceToTarget;

    private void Update()
    {
        distanceToTarget = Vector2.Distance(followTarget.position, transform.position);

        if (distanceToTarget < followDistance)
            return;

        // Move the pet towards the target position
        transform.position = Vector2.MoveTowards(transform.position, followTarget.position, followSpeed * Time.deltaTime);
    }
}
