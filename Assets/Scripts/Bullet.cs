using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(Vector3.forward * 1f);
        Outcheck();

    }
    void Outcheck()
    {
        if (transform.position.y < 0.5 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }

    }
}