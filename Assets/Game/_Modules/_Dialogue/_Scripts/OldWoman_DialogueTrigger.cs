using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWoman_DialogueTrigger : DialogueTrigger
{
    public static Action OnOldWomanDialogue = null;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, DialogueCallback);
    }

    void DialogueCallback()
    {
        OnOldWomanDialogue?.Invoke();
    }
}
