using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapons,
    Items,
    Consumable

}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string description;
}
