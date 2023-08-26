using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper_QuestDialogue : MonoBehaviour, IInteractables
{
    [SerializeField] Village2Script _sceneScript;
    [SerializeField] DialogueTrigger _dialogueTrigger;

    public void Interact()
    {
        _dialogueTrigger.PlayDialogue(EnableTeleport);

    }

    void EnableTeleport()
    {
        _sceneScript.EnableTeleport();
    }

}
