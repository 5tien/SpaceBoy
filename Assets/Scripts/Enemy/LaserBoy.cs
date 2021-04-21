using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBoy : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float shootTime = 5f;
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
            Destroy(gameObject);
        }

        if (shootTime <= 0 && laser != null)
        {
            shootTime = Random.Range(4, 6);

            GameObject newBullet = Instantiate(laser, transform.position + new Vector3(0, -0.1f, -1.4f), Quaternion.identity);

            newBullet.GetComponent<Laser>().direction = new Vector3(0, 0, -8);
            newBullet.GetComponent<BoxCollider>().isTrigger = true;
            newBullet.tag = "EnemyLaser";
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
}
