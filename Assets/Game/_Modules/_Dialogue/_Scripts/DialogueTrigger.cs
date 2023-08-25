using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractables
{
    [SerializeField] bool isAutoTrigger;
    [SerializeField] protected DialogueSO _dialogue;
    [SerializeField, ReadOnly] bool canShowDialogue; 

    public static Action<DialogueSO, Action> OnDialogueInteracted = null;

    private void Start()
    {
        canShowDialogue = true;
    }

    public virtual void Interact()
    {
        if (isAutoTrigger) return;

        OnDialogueInteracted?.Invoke(_dialogue, null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAutoTrigger || !canShowDialogue) return;
        canShowDialogue = false;

        OnDialogueInteracted?.Invoke(_dialogue, null);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canShowDialogue = true;
    }

}
