using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   /* public WeaponsSO weaponData;
    public EnemyData enemy;
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
        EnemyAI enemy = other.GetComponent<EnemyAI>(); // Di�er collider'�n ba�l� oldu�u EnemyAI bile�enini al

        if (enemy != null) // E�er enemy de�i�keni null de�ilse, yani EnemyAI bile�enini ald�ysa
        {
            enemy.TakeDamage(weaponData); 
        }
    }

    private void DisableCollider()
    {
        
    } */
}
