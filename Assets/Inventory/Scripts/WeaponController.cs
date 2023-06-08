using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponsSO weaponData;
    public Collider2D weaponCollider;

    private void Start()
    {
        weaponCollider = GetComponent<Collider2D>();
        weaponCollider.enabled = false; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weaponCollider.enabled = true;
            Invoke("DisableCollider", 0.2f);

            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            enemy.TakeDamage(weaponData);
        }
    }

    private void DisableCollider()
    {
        weaponCollider.enabled = false;
    }
}
