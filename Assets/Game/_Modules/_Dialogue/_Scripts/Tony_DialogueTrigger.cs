using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tony_DialogueTrigger : DialogueTrigger
{
    [SerializeField] private ChaseCutscene chaseCutscene;

    [SerializeField] private bool stealRat;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, ContinueChase);
    }

    private void ContinueChase()
    {
        if (stealRat)
        {
            chaseCutscene.StealRat();
        }
        else
        {
            chaseCutscene.EndChaseDialogue();
        }
    }
}
