using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float maxSize;
    
    void Update()
    {
        if (transform.localScale.y < maxSize)
        {
            transform.localScale = new Vector3(0, transform.localScale.y + Time.deltaTime, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
