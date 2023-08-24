using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CratePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<CratePuzzleCrate> crates;
    [SerializeField] private List<CratePuzzleTrigger> cratePuzzleTriggers;

    [SerializeField] private UnityEvent onPuzzleComplete;

    private void Awake()
    {
        foreach (var trigger in cratePuzzleTriggers)
        {
            trigger.CrateOnTrigger += ValidatePuzzle;
        }
    }

    private void ValidatePuzzle()
    {
        bool completed = true;
        foreach (var trigger in cratePuzzleTriggers)
        {
            if (!trigger.IsCrateOnPlace)
            {
                completed = false;
                break;
            }
        }

        if (completed)
        {
            onPuzzleComplete.Invoke();
        }
    }

    public void ResetPuzzle()
    {
        foreach (var crate in crates)
        {
            crate.ResetPosition();
        }
    }

    private void OnDestroy()
    {
        foreach (var trigger in cratePuzzleTriggers)
        {
            trigger.CrateOnTrigger -= ValidatePuzzle;
        }
    }
}
