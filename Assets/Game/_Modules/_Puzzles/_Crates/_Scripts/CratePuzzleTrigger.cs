using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CratePuzzleTrigger : MonoBehaviour
{
    public bool IsCrateOnPlace { get; private set; }

    public UnityAction CrateOnTrigger;

    private const string crateTag = "CratePuzzle";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(crateTag))
        {
            IsCrateOnPlace = true;

            CrateOnTrigger.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(crateTag))
        {
            IsCrateOnPlace = false;

            CrateOnTrigger.Invoke();
        }
    }
}
