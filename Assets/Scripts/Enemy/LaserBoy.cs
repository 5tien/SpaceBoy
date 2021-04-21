using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBoy : MonoBehaviour
{
    [SerializeField] private GameObject laser;
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

        if (shootTime <= 0 && laser != null)
        {
            shootTime = Random.Range(2, 3);

            GameObject newBullet = Instantiate(laser, transform.position, Quaternion.identity);

            newBullet.GetComponent<BulletHit>().direction = new Vector3(0, 0, -Time.deltaTime * 3);
            newBullet.gameObject.tag = "EnemyLaser";
            newBullet.GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
}
