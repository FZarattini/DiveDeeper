using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class OldMan_DialogueTrigger : DialogueTrigger
{
    [SerializeField] DialogueSO _secondDialogue;
    [SerializeField, ReadOnly] DialogueSO _currentDialogue;

    [SerializeField] GameObject _closedBasementEntrance;
    [SerializeField] GameObject _openedBasementEntrance;

    private void OnEnable()
    {
        _currentDialogue = _dialogue;
        OldWoman_DialogueTrigger.OnOldWomanDialogue += ChangeDialogue;

    }

    private void OnDisable()
    {
        OldWoman_DialogueTrigger.OnOldWomanDialogue -= ChangeDialogue;
    }

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_currentDialogue, DialogueCallback);
    }

    void DialogueCallback()
    {
        if(_currentDialogue == _dialogue) return;

        OpenBasement();
    }

    void ChangeDialogue()
    {
        _currentDialogue = _secondDialogue;
    }

    void OpenBasement()
    {
        _closedBasementEntrance.SetActive(false);
        _openedBasementEntrance.SetActive(true);
    }
}
