using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName ="Inventory System/Items/Weapon")]



public class WeaponsSO : ItemObject
{
    public float durability;
    public int baseDamage;

    public void Awake()
    {
        type = ItemType.Weapons;
    }

    public void DecreaseDurability(float amount)
    {
        durability -= amount;

        if (durability <= 0)
        {
            Break();
        }
    }

    public void DealDamage(EnemyData enemy)
    {
        enemy.TakeDamage(baseDamage);
        DecreaseDurability(1.0f);
    }

    private void Break()
    {
        
    }
}
