using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;

    private void Start()
    {
        slider.maxValue = playerHealth.maxHealth;
        
    }

    public void UpdateHealthBar()
    {
        slider.value = playerHealth.GetCurrentHealth();
    }

    private void Update()
    {
        UpdateHealthBar();
    }
}
