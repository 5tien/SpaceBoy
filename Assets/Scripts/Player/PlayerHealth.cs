using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float timeElapsed;
    private float redTimeElapsed;
    public override void Start()
    {
        base.Start();
        timeElapsed = invincibilityDuration;
    }
    private void Update()
    {
        if (timeElapsed < invincibilityDuration)
        {
            timeElapsed += Time.deltaTime;
        }
        
        if (redTimeElapsed < 0.15f)
        {
            HealthbarRed = true;
            redTimeElapsed += Time.deltaTime;
        }
        else
        {
            HealthbarRed = false;
        }
    }

    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
    }

    protected override void CheckHealth()                            //This function will execute actions based off the amount of health is currently being heald by the player.
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        else
        {
            Debug.Log("Damage taken");
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public override void Kill()
    {
        base.Kill();
    }

    void OnTriggerEnter(Collider other)
    {
        if (timeElapsed >= invincibilityDuration)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
            {
                ChangeHealth(-damagePerHit);
                timeElapsed = 0;
                redTimeElapsed = 0;
                if (other.gameObject.CompareTag("EnemyBullet"))
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
