using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private bool canAttack = true;

    private void Update()
    {
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            
            Vector2 direction = (player.position - transform.position).normalized;
            transform.right = direction;

            if (distanceToPlayer <= attackRange && canAttack)
            {
                
                Attack();
            }
        }
    }

    private void Attack()
    {
        canAttack = false;

        // Projektil oluþtur ve ateþle
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 10f;

        
        Invoke("ResetAttack", attackCooldown);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
