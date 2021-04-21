using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private float spawnTime = 3;

    void Update()
    {
        if (spawnTime <= 0)
        {
            spawnTime = Random.Range(1, 3);

            GameObject enemy = enemy1;
            int random = Random.Range(0, 3);

            if (random == 1)
            {
                enemy = enemy1;
            }
            else if (random == 2)
            {
                enemy = enemy2;
            }
            else if (random == 3)
            {
                enemy = enemy3;
            }

            GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.Range(-4, 4), 0, 0), Quaternion.Euler(0, -180, 0));

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
