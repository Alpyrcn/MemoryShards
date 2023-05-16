
public class HealthSystem 
{
    private int Maxhealth;
    private int health;



    public HealthSystem(int health)
    {
        this.health = health;
        health = Maxhealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return health / Maxhealth;
    }
    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health < 0) health = 0;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > Maxhealth) health = Maxhealth;
    }

    public void Die()
    {
        
    }
}
