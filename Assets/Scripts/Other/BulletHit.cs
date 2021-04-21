using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] public float speed;

    private Renderer render;
    private Rigidbody rigid;

    private GunAndScore scoreScript;
    private Shooter shootScript;

    private float bulletHealthS;
    private float bulletHealthM;
    private float damage;


    void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.CompareTag("Enemy") && transform.tag == "PlayerBullet"))
        {
            if (shootScript.CurrentGun == 1)    //if the selexted weapon is the machinegun damage is awlays set
            {
                if (bulletHealthM > collision.transform.GetComponent<EnemyHealth>().Health)     //Caps off the bullet damage at the health of the enemy
                {
                    damage = collision.transform.GetComponent<EnemyHealth>().Health;
                }
                else
                {
                    damage = bulletHealthM;
                };

                if (collision.transform.GetComponent<EnemyHealth>() != null)
                {
                    collision.transform.GetComponent<EnemyHealth>().ChangeHealth(damage);
                    scoreScript.damageDone += damage;
                }

                bulletHealthM -= (100 - collision.transform.GetComponent<EnemyHealth>().Health);
            }
            else if (shootScript.CurrentGun == 2)   //The single shot gun will do more damage depending on its size
            {
                if (bulletHealthS > collision.transform.GetComponent<EnemyHealth>().Health)
                {
                    damage = collision.transform.GetComponent<EnemyHealth>().Health;
                }
                else
                {
                damage = bulletHealthS;
                }

                if (collision.transform.GetComponent<EnemyHealth>() != null)
                {
                    collision.transform.GetComponent<EnemyHealth>().ChangeHealth(damage);
                    scoreScript.damageDone += damage;               
                }

                bulletHealthS -= (100 - collision.transform.GetComponent<EnemyHealth>().Health);
            }
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.transform.GetComponent<Collider>());
        }
    }

    void Start()
    {
        render = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
        shootScript = FindObjectOfType<Shooter>();
        scoreScript = FindObjectOfType<GunAndScore>();
        
        bulletHealthS = shootScript.bulDamageS + (transform.localScale.x - shootScript.singleBNSize) * shootScript.bulDamageMultiplier * shootScript.bulDamageS;
        bulletHealthM = shootScript.bulDamageM;
    }

    void Update()
    {
        //out of bounds the bullet will despawn
        if (render.isVisible == false)
        {
            Destroy(gameObject);
        }

        //if the bullethas dealth all damage it had it will despawn
        if (bulletHealthS <= 0 || bulletHealthM <= 0)
        {
            Destroy(gameObject);
        }

        rigid.velocity = transform.forward * speed;
    }
}
