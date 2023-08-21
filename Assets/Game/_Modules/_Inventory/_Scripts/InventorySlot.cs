using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData ItemInSlot { get; private set; }

    [SerializeField] private Image itemIcon;

    public void AddItem(ItemData item)
    {
        ItemInSlot = item;

        itemIcon.sprite = item.Icon;
        itemIcon.enabled = true;
    }

    public void RemoveItem()
    {
        ItemInSlot = null;

        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
}
