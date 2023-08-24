using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Collider2D mainCollider;

    private FollowTarget followTarget;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            TakeDamage();
        }
    }
}
