using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] public Vector3 direction;

    private Renderer render;
    private Rigidbody rigid;

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.CompareTag("Enemy") && transform.tag == "PlayerBullet") || (collision.transform.CompareTag("Player") && transform.tag == "EnemyBullet"))
        {
            if (collision.transform.GetComponent<Shooter>())
            {

            }
            if (collision.transform.GetComponent<EnemyHealth>() != null)
            {
                collision.transform.GetComponent<EnemyHealth>().ChangeHealth(-transform.localScale.x * 5);
            }

            Destroy(gameObject);
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
    }

    void Update()
    {
        if (render.isVisible == false)
        {
            Destroy(gameObject);
        }

        rigid.velocity = direction;
    }
}
