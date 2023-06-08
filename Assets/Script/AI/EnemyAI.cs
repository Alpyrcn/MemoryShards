using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;
    private WeaponsSO weaponSo;

    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private PlayerHealth playerHealth;
    private HealthSystem healthSystem;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        gameObject.tag = "Enemy";

        playerHealth = FindObjectOfType<PlayerHealth>();
        healthSystem = new HealthSystem(enemyData.health);
        currentHealth = enemyData.health;

    }

    void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }
    }
    public void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(enemyData.damage);
        }
    }

    public void TakeDamage(WeaponsSO weapons)
    {
        int effectiveDamage = weapons.baseDamage - enemyData.health;

        currentHealth -= effectiveDamage;

        
        AudioManager.Instance.PlaySFX("SkellyHurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        
        anim.SetBool("Death", true);
        // Düþman nesnesi deðiþtirilebilir veya yok edilebilir.

        Destroy(gameObject); // Düþman nesnesini yok etme örneði
    }
}
