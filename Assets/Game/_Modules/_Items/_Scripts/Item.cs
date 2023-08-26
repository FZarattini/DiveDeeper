using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractables
{
    [SerializeField] private ItemData itemData;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public static Action OnItemPickUP;

    private void Awake()
    {
        LoadItem();
    }

    private void LoadItem()
    {
        if (itemData == null)
            return;

        name = itemData.Name;
        spriteRenderer.sprite = itemData.Icon;
    }

    public void Interact()
    {
        InventoryManager.Instance.AddItem(itemData);

        OnItemPickUP?.Invoke();

        Destroy(gameObject);
    }

    private void OnValidate()
    {
        LoadItem();
    }
}
