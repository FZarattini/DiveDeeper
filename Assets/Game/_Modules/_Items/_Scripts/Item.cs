using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractables
{
    [SerializeField] private ItemData itemData;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        LoadItem();
    }

    private void LoadItem()
    {
        name = itemData.Name;
        spriteRenderer.sprite = itemData.Icon;
    }

    public void Interact()
    {
        InventoryManager.Instance.AddItem(itemData);

        Destroy(gameObject);
    }

    private void OnValidate()
    {
        LoadItem();
    }
}
