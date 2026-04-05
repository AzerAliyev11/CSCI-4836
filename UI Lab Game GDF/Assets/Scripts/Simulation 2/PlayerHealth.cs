using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.Instance.SetHealth(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    
    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HealthBar.Instance.SetHealth(currentHealth);
    }
}
