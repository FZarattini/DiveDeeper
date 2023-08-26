using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class RatGuide : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryDetectTarget();
    }

    void TryDetectTarget()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, detectionRange);

        foreach (Collider2D collider in colliderArray)
        {
            if (collider.GetComponent<PlayerController>())
                transform.DOMove(targetTransform.position, 0.5f).OnComplete(delegate { Destroy(gameObject); });
        }
    }
}
