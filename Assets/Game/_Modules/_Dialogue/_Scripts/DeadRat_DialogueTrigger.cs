using Doozy.Runtime.UIManager.Containers;
using System;
using UnityEngine;

public class DeadRat_DialogueTrigger : DialogueTrigger
{
    [SerializeField] private UIContainer container;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, DialogueCallback);
    }

    void DialogueCallback()
    {
        container.Show();
    }
}
