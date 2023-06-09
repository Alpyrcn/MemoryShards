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
        EnemyAI enemy = other.GetComponent<EnemyAI>(); // Diðer collider'ýn baðlý olduðu EnemyAI bileþenini al

        if (enemy != null) // Eðer enemy deðiþkeni null deðilse, yani EnemyAI bileþenini aldýysa
        {
            enemy.TakeDamage(weaponData); 
        }
    }

    private void DisableCollider()
    {
        
    } */
}
