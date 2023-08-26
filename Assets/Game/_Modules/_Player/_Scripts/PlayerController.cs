using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] private bool canAttack;

    [SerializeField] private Collider2D attackCollider;

    [SerializeField, Range(0, 100)] private float knockbackForce;

    [SerializeField] AudioSource _attackAudioSource;

    public void Attack()
    {
        if (!canAttack)
            return;

        StartCoroutine(PerformAttack());
    }

    private IEnumerator PerformAttack()
    {
        if (!GameManager.Instance.IsAttacking)
        {
            GameManager.Instance.IsAttacking = true;
            attackCollider.enabled = true;
            _attackAudioSource.Play();

            yield return new WaitForSeconds(0.5f);

            GameManager.Instance.IsAttacking = false;
            attackCollider.enabled = false;
        }
    }

    public override void MoveCharacter(Vector2 moveVector, float speed)
    {
        if (GameManager.Instance.IsGettingKnockback)
            return;

        base.MoveCharacter(moveVector, speed);
    }

    private IEnumerator Knockback(GameObject target)
    {
        GameManager.Instance.IsGettingKnockback = true;

        Vector2 direction = (transform.position - target.transform.position).normalized;

        _rigidBody.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f);

        GameManager.Instance.IsGettingKnockback = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.Instance.IsGettingKnockback)
                return;

            StartCoroutine(Knockback(collision.gameObject));
        }
    }
}
