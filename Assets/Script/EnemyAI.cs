using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;

    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private HealthSystem healthSystem;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        gameObject.tag = "Player";

        // HealthSystem sýnýfýndan yeni bir instance oluþturarak düþmanýn saðlýðýný set ediyoruz.
        healthSystem = new HealthSystem(enemyData.health);
    }

    void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        // Düþmanýn saðlýðý %0'a düþtüðünde, Die() metodu çaðrýlýr.
        if (healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * enemyData.speed * Time.deltaTime));
    }

    private void Die()
    {
        // Burada düþmanýn ölüm animasyonu oynatýlabilir veya düþman objesi yok edilebilir.
        Destroy(gameObject);
    }
}
