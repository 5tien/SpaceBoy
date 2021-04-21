using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private float speed = 2;
    [SerializeField] public bool followPlayer = false;
    
    void Update()
    {

        if (target != null)
        {
            float direction = 0;

            if (target.transform.position.x > transform.position.x + 0.25f && target.transform.position.z < transform.position.z)
            {
                direction = 1;
            }
            else if (target.transform.position.x < transform.position.x - 0.25f && target.transform.position.z < transform.position.z)
            {
                direction = -1;
            }

            if (followPlayer == false)
            {
                direction = 0;
            }

            transform.position += new Vector3(direction * Time.deltaTime * speed, 0, -Time.deltaTime * 3);
        }
    }
}
