using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        InventorySlot slot = GetSlotWithItem(item);
        if (slot == null)
        {
            slot = GetEmptySlot();
            if (slot == null)
            {
                Debug.LogWarning("Inventory is full!");
            }
            else
            {
                slot.AddItem(item);
            }
        }
    }

    public void UseItem(ItemData item)
    {
        InventorySlot slot = GetSlotWithItem(item);
        slot?.RemoveItem();
    }

    private InventorySlot GetEmptySlot()
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.ItemInSlot == null)
                return slot;
        }

        return null;
    }

    private InventorySlot GetSlotWithItem(ItemData item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.ItemInSlot == item)
                return slot;
        }

        return null;
    }
}
