using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarborScript : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] GameObject exitCollider;
    [SerializeField] GameObject exitTrigger;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }

    private void OnEnable()
    {
        Item.OnItemPickUP += CheckInventory;
    }

    private void OnDisable()
    {
        Item.OnItemPickUP -= CheckInventory;
    }

    void CheckInventory()
    {
        if (inventory.ItemsInInventory >= 5)
            EnableExit();
    }

    void EnableExit()
    {
        exitCollider.SetActive(false);
        exitTrigger.SetActive(true);
    }
}
