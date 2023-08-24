using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratePuzzleReset : MonoBehaviour
{
    [SerializeField] private CratePuzzleManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.ResetPuzzle();
    }
}
