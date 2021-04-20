using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float Health = 1;

    public void ChangeHealth(float amount)
    {
        Health += amount;

        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
