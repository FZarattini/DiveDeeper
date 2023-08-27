using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper_QuestDeliveryDialogue : DialogueTrigger, IInteractables
{
    [SerializeField] ChaseCutscene _chaseCutscene;

    public override void Interact()
    {
        PlayDialogue(ClearInventory);
    }

    public void ClearInventory()
    {
        InventoryManager.Instance.ClearInventoryExceptCheese();
        _chaseCutscene.StartChase();
    }
}
