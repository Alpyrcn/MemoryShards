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

    public GameObject Weapon;
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
            playerHealth._TakeDamage(enemyData.damage);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        
        AudioManager.Instance.PlaySFX("SkellyHurt");

        if (currentHealth <= 0)
        {
            Die();
            
        }

    }
    private void Die()
    {
        Debug.Log("Skelly Died :(");
        //anim.SetInteger("Death", 1);

        

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
