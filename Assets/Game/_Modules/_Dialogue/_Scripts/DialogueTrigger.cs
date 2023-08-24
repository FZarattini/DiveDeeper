using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractables
{
    [SerializeField] protected DialogueSO _dialogue;

    public static Action<DialogueSO, Action> OnDialogueInteracted = null;

    public virtual void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, null);
    }

}
