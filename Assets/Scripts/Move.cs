using UnityEngine;

using System.Collections;

public class Move : MonoBehaviour
{
    // //은 주석 입니다.
    // Vector2는 X, Y 값을 가집니다.
    // Vector3는 X, Y, Z 값을 가집니다.

    public float moveSpeed = 30;
    public float rotSpeed = 0.2f;

    public float rotationSpeed = 5.0f;
    Rigidbody body;

    public bool isPlayerMove;
    public bool GameOver = false;

    public GameObject explosion;

    void Start()
    {
        isPlayerMove = false;
    }

    void Update()
    {

        TextControl textcontrol = GameObject.Find("Screen").GetComponent<TextControl>();
        isPlayerMove = textcontrol.isStart;

        float h = Input.GetAxis("Horizontal");


        if (isPlayerMove == true && GameOver == false)
        {

            transform.Rotate(Vector3.up, h * rotSpeed);

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.CompareTag("Barrier") || col.gameObject.CompareTag("Enemy"))        
        {
            GameOver = true;

            Explosion();
        }
    }
    void Explosion()
    {
        isPlayerMove = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

}