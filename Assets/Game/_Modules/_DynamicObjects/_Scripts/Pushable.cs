using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    private Rigidbody2D rgbd;

    [SerializeField] private bool canBePushed = true;

    private Vector2 pushDirection;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            pushDirection = (player.transform.position - transform.position).normalized;
            if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.y))
            {
                rgbd.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rgbd.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

            player.PushDirection = pushDirection;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            rgbd.constraints = RigidbodyConstraints2D.FreezeRotation;

            player.PushDirection = Vector2.zero;
        }
    }
}
