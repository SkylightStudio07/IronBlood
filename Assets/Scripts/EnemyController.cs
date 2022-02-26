using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private Transform Player;
    public NavMeshAgent nav;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }

        nav.SetDestination(Player.position);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
