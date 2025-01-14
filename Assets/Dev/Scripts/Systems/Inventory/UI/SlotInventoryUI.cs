using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SlotInventoryUI : MonoBehaviour
{
    [SerializeField] Image spriteItem;
    string description;
    [SerializeField] TextMeshProUGUI description_txt;
    [SerializeField] TextMeshProUGUI amount_txt;



    public void SetSlotUI(InventorySlot slotItem)
    {
        spriteItem.sprite = slotItem.item.itemData.sprite;
        amount_txt.text = slotItem.amount.ToString();
        description = slotItem.item.itemData.description;
    }

    public void SetNoItem()
    {
        spriteItem.sprite = null;
        description_txt.text = "";
        description = "";
        amount_txt.text = "";
    }

    public void SetDescriptionOnItemSelected(bool onOff)
    {
        if (onOff) description_txt.text = description;
        else description_txt.text = "";
    }
}
