using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventorySO inventory;

    public int X_Space_Between_Item;
    public int Number_Of_Column;
    public int Y_Space_Between_Items;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

}
