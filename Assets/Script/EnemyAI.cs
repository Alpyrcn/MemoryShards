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

    private PlayerHealth playerHealth;
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
        gameObject.tag = "Enemy";

        // HealthSystem s�n�f�ndan yeni bir instance olu�turarak d��man�n sa�l���n� set ediyoruz.
        playerHealth = FindObjectOfType<PlayerHealth>();
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

        // D��man�n sa�l��� %0'a d��t���nde, Die() metodu �a�r�l�r.
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

        anim.SetBool("Moving", true);
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
    private void Die()
    {
        // �l�m i�lemleri burada ger�ekle�tirilir.
        // �rne�in, animasyon oynat�labilir veya ses �al�nabilir.
        // D��man nesnesi de�i�tirilebilir veya yok edilebilir.

        Destroy(gameObject); // D��man nesnesini yok etme �rne�i
    }
}
