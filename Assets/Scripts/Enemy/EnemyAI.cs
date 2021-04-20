using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootTime = 1;
    [SerializeField] private float speed = 2;
    [SerializeField] public bool followPlayer = false;
    [SerializeField] public Renderer renderer1;

    private void Start()
    {
        renderer1 = transform.GetComponent<Renderer>();
    }

    void Update()
    {
        if (renderer1.isVisible == false)
        {
            Destroy(gameObject);
        }

        if (shootTime <= 0 && bullet != null)
        {
            shootTime = Random.Range(2, 3);

            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.GetComponent<BulletHit>().direction = new Vector3(0, 0, -5);
            newBullet.gameObject.tag = "EnemyBullet";
            newBullet.GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }


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
