using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Items/Item")]
public class ItemsSO : ItemObject
{
    public void Awake()
    {
        type = ItemType.Items;
    }
}
