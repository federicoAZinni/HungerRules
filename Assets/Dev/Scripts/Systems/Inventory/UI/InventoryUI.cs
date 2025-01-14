using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] List<SlotInventoryUI> slotsUI;
    private void OnEnable()
    {
        inventory.OnAddItem += RefreshUIInventory;
        inventory.OnRemoveItem += RefreshUIInventory;
        RefreshUIInventory();
    }
    private void OnDisable()
    {
        inventory.OnAddItem -= RefreshUIInventory;
        inventory.OnRemoveItem -= RefreshUIInventory;

    }

    void RefreshUIInventory()
    {
        for (int i = 0; i < inventory.inventory.Length; i++) 
        {
            if(inventory.inventory[i].item == null) slotsUI[i].SetNoItem(); 
            else slotsUI[i].SetSlotUI(inventory.inventory[i]);
        }
    }
}
