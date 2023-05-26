using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;


    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);


        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        // Ölüm iþlemleri burada gerçekleþtirilir.
        // Örneðin, oyunu yeniden baþlatabilir veya oyunu durdurabilirsiniz.

        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }
}

