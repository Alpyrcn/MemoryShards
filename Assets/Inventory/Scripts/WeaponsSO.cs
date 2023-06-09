using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName ="Inventory System/Items/Weapon")]



public class WeaponsSO : ItemObject
{

    public EnemyData enemyData;
    public float durability;
    public int baseDamage;
    public Collider weaponCollider;
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


    private void Break()
    {
        
    }

    public void Damage(EnemyData enemyData)
    {
        int effectiveDamage = baseDamage - enemyData.health;

        enemyData.health -= effectiveDamage;
    }
}
