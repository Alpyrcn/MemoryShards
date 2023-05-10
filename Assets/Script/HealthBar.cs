using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public Slider slider;

    private void Start()
    {
        healthSystem = new HealthSystem(20);
        slider.maxValue = 20;
        healthbar();
    }

    public void healthbar()
    {
        slider.value = healthSystem.GetHealth();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthSystem.Damage(5);
            healthbar();

            
        }

    }
}
