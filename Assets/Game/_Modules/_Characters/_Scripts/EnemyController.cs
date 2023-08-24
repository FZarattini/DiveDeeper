using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Collider2D mainCollider;

    private FollowTarget followTarget;

    [SerializeField] float detectionRange;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCollider = GetComponent<Collider2D>();

        followTarget = GetComponent<FollowTarget>();
    }

    private void TakeDamage()
    {
        followTarget.enabled = false;
        mainCollider.enabled = false;
        animator.SetTrigger("Death");
    }

    private void Update()
    {
        TryDetectTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            TakeDamage();
        }
    }

    private void TryDetectTarget()
    {
        if (followTarget.FollowEnabled) return;

        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, detectionRange);

        foreach(Collider2D collider in colliderArray)
        {
            if (collider.GetComponent<PlayerController>())
                followTarget.EnableFollow(true);
        }

    }
}
