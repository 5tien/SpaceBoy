using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [Range(1, 10)]  public float maxHealth = 3;
    public float damagePerHit = 1;
    public float currentHealth;

    [Header("Extra Settings")]
    [Range(0, 5)] public float invincibilityDuration;
    public bool HealthbarRed = false;

    public virtual void Start()
    {
        currentHealth = maxHealth;                                   
    }

    public virtual void ChangeHealth(float amount)
    {
        currentHealth = currentHealth + amount;                     
        CheckHealth();                                              
    }

    protected virtual void CheckHealth()                            //This function will execute actions based off the amount of health is currently being heald by the player.
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Kill()
    {
        Debug.Log("you died");
    }
}
