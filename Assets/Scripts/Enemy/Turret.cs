using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float turnSpeed = 1;

    [Header("Shooter")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootTime = 1;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation((transform.position - target.transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);

        if (shootTime <= 0)
        {
            shootTime = 1;

            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.tag = "EnemyBullet";
            newBullet.GetComponent<BulletHit>().speed = -4;
            newBullet.GetComponent<BoxCollider>().isTrigger = true;
            newBullet.transform.rotation = Quaternion.LookRotation((transform.position - target.transform.position).normalized);
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
}
