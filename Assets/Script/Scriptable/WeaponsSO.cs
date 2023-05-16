using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName ="Inventory System/Items/Weapon")]

public class WeaponsSO : ItemObject
{
    public float durability;
    public float baseDamage;

    public void Awake()
    {
        type = ItemType.Weapons;
    }
}
