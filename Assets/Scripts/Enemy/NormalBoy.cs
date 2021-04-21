using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBoy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootTime = 1;
    [SerializeField] public Renderer render;

    void Start()
    {
        render = transform.GetComponent<Renderer>();
        shootTime = (Random.Range(0, 10) / 10);
    }

    void Update()
    {
        if (render.isVisible == false)
        {
            //Destroy(gameObject);
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
    }
}
