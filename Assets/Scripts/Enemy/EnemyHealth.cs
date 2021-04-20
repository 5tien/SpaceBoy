using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 1;
    private GunAndScore scoreScript;


    private void Start()
    {
        scoreScript = FindObjectOfType<GunAndScore>();
    }

    public void ChangeHealth(float amount)
    {
        Health += amount;

        if (Health <= 0)
        {
            Destroy(transform.gameObject);
            scoreScript.EnemiesKilled += 1;
        }
    }
}
