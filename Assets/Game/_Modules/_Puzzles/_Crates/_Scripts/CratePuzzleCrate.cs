using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratePuzzleCrate : MonoBehaviour
{
    private Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
