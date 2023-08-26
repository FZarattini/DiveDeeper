using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindRat_DialogueTrigger : DialogueTrigger
{
    [SerializeField] private DialogueTrigger dialogueSequence;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, ShowDialogueSequence);
    }

    private void ShowDialogueSequence()
    {
        dialogueSequence.Interact();
    }
}
