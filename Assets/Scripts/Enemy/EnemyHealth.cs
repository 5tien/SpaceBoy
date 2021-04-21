using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100;

    private GunAndScore scoreScript;

    private void Start()
    {
        scoreScript = FindObjectOfType<GunAndScore>();
    }

    //This function is triggert by the BulletHit script if the enemy gets hit with a bullet
    public void ChangeHealth(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(transform.gameObject);
            scoreScript.EnemiesKilled += 1;
        }
    }
}
