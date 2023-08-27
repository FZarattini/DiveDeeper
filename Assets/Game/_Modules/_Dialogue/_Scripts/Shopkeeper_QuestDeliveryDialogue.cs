using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper_QuestDeliveryDialogue : MonoBehaviour, IInteractables
{
    [SerializeField] DialogueTrigger _dialogueTrigger;
    [SerializeField] ChaseCutscene _chaseCutscene;

    public void Interact()
    {
        _dialogueTrigger.PlayDialogue(ClearInventory);
    }

    public void ClearInventory()
    {
        InventoryManager.Instance.ClearInventoryExceptCheese();
        _chaseCutscene.StartChase();
    }
}
