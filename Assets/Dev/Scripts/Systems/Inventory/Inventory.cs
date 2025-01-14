using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int inventoryLenght;
    public InventorySlot[] inventory ; 
    [SerializeField] Item itemTest;
    [SerializeField] Item itemTest2;


    #region Events
    public Action OnAddItem;
    public Action OnRemoveItem;
    public Action OnUseItem;
    #endregion

    private void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) AddItem(itemTest);
        if (Input.GetKeyDown(KeyCode.X)) AddItem(itemTest2);
        if (Input.GetKeyDown(KeyCode.V)) UseItem(0);
        if (Input.GetKeyDown(KeyCode.B)) UseItem(1);
    }
    public void AddItem(Item newItem, int amount = 1)
    {
        if(AlreadyExistItemInInventory(newItem, out InventorySlot slot)) //Search if already exist an item similar to the new item, if exist just add the amount on the item.
        {
            slot.amount += amount;

            Debug.Log($"Item: {slot.item.name}, " +
                $"with Amount: {slot.amount} ,  " +
                $"Was Added to the inventory");
        }
        else
        { 
            // If not, add the item in the inventory.
            InventorySlot itemSlot = new InventorySlot(amount, newItem);
            int freeSlot = FreeSlotIndex();
            inventory[freeSlot] = itemSlot;

            Debug.Log($"Item: {itemSlot.item.name}, " +
                    $"with Amount: {itemSlot.amount} ,  " +
                    $"Was Added to the inventory");
        }

        OnAddItem?.Invoke();
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        if(AlreadyExistItemInInventory(item, out InventorySlot slot))
        {
            slot.amount -= amount;
                Debug.Log($"Item: {slot.item.name}, " +
                $"with Amount: {slot.amount} ,  " +
                $"Was Removed to the inventory");

            if (slot.amount == 0)
                inventory[GetSlotWithSameItem(slot.item)] = new InventorySlot(0,null);
        }

        OnRemoveItem?.Invoke();
    }

    public void UseItem(int indexSlotOfItemUsed)
    {
        Item itemUsed = inventory[indexSlotOfItemUsed].item;

        if (indexSlotOfItemUsed < 0|| indexSlotOfItemUsed >= inventory.Length || itemUsed == null) { Debug.Log("InventorySlot Null"); return; }
            
        switch (itemUsed.itemData.itemType) //Depending the Type of the item, do something
        {
            case ItemType.Consumable:
                itemUsed.Consume();
                RemoveItem(itemUsed);
                break;
            case ItemType.Weapon:
                itemUsed.Attack();
                break;
            case ItemType.Craft:
                break;
            default:
                break;
        }

        OnUseItem?.Invoke();    
    }



    private bool AlreadyExistItemInInventory(Item itemToSearch, out InventorySlot itemSlot)
    {
        itemSlot = null;

        foreach (InventorySlot slot in inventory)
        {
            if(slot.idItem == itemToSearch.itemData.id)
            {
                itemSlot = slot;
                return true;
            }
        }
        return false;
    }

    int FreeSlotIndex()
    {
        for (int i = 0; i < inventory.Length; i++)
            if (inventory[i].item == null) return i;
        
        Debug.Log("Error No free Slot");
        return -1;
    }

    int GetSlotWithSameItem(Item item)
    {
        for (int i = 0; i < inventory.Length; i++)
            if (item.itemData.id == inventory[i].idItem) return i;

        return FreeSlotIndex();
    }

    public bool HasItem(Item itemToSearch, int amount = 1)
    {
        foreach (InventorySlot slot in inventory)
        {
            if (slot.item != null && slot.item.itemData.id == itemToSearch.itemData.id && slot.amount >= amount)
            {
                return true;
            }
        }
        return false;
    }


}



[System.Serializable]
public class InventorySlot
{
    public int idItem;
    public int amount;
    public Item item;

    public InventorySlot(int amount, Item item)
    {
        this.idItem = item != null ? item.itemData.id : 0; 
        this.amount = amount;
        this.item = item;
    }
}
