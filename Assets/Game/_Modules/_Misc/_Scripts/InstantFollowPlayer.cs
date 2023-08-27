using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void Update()
    {
        transform.position = playerTransform.position;
    }
}
