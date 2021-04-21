using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] public Vector3 direction = new Vector3(0, 0, -8);
    [SerializeField] private float maxSize;
    [SerializeField] private float speed;
    [SerializeField] private bool reverted = false;

    [SerializeField] private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.localScale.z < maxSize && reverted == false)
        {
            transform.localScale = transform.localScale + new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if (transform.localScale.z > 0)
        {
            reverted = true;

            transform.localScale = transform.localScale - new Vector3(0, 0, (speed * 5) * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }

        rigid.velocity = direction;
    }
}
