using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Animator anim;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void _TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        AudioManager.Instance.PlaySFX("Death");


        if (currentHealth <= 0)
        {
           

            Die();
        }
    }



    private void Die()
    {
        
        anim.SetTrigger("IsDeath");


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _TakeDamage(5);
        }

    }
}

