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
    [SerializeField] bool autoDestroy;
   

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

    void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void PlayDialogue(Action callback)
    {
        OnDialogueInteracted?.Invoke(_dialogue, callback);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAutoTrigger || !canShowDialogue) return;
        canShowDialogue = false;

        if(!autoDestroy)
            OnDialogueInteracted?.Invoke(_dialogue, null);
        else
            OnDialogueInteracted?.Invoke(_dialogue, AutoDestroy);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canShowDialogue = true;
    }

}
