using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private float spawnTime = 3;

    void Update()
    {
        if (spawnTime <= 0)
        {
            spawnTime = Random.Range(1, 3);

            GameObject newEnemy = Instantiate(enemy1, transform.position + new Vector3(Random.Range(-4, 4), 0, 0), Quaternion.identity);

            newEnemy.GetComponent<EnemyAI>().target = player;

            if (Random.Range(0, 4) == 3)
            {
                newEnemy.GetComponent<EnemyAI>().followPlayer = true;
            }
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
}
