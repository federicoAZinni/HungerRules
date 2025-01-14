using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class ItemData : ScriptableObject
{
    public int id;
    [Space(5)]
    public string itemName;
    [Space(5)]
    public Sprite sprite;
    [Space(5)]
    public ItemType itemType;
    [Space(5)]
    [TextArea(20,20)]
    public string description;
}

public enum ItemType
{
    Consumable,
    Weapon,
    Craft
}
