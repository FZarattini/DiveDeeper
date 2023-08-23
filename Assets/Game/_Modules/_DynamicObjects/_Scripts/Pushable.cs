using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    private Rigidbody2D rgbd;

    [SerializeField] private bool canBePushed = true;
    [SerializeField] Rigidbody2D playerRB = null;
    [SerializeField] RigidbodyConstraints2D playerConstraints;

    private Vector2 pushDirection;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player == null) return;
        
        playerRB = player.GetComponent<Rigidbody2D>();
        if(playerRB == null) return;

        SavePlayerConstraints();

        if (player != null)
        {
            pushDirection = (player.transform.position - transform.position).normalized;
            if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.y))
            {
                if (playerRB.velocity.x != 0 && playerRB.velocity.y == 0)
                {
                    rgbd.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
            }
            else
            {
                if (playerRB.velocity.y != 0 && playerRB.velocity.x == 0)
                {
                    rgbd.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
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
            ReloadConstraints();

            player.PushDirection = Vector2.zero;
        }
    }

    void SavePlayerConstraints()
    {
        playerConstraints = playerRB.constraints;
    }

    void ReloadConstraints()
    {
        playerRB.constraints = playerConstraints;
    }
}
