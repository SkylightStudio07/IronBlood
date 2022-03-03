using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public bool view = true; // true = ž��
                            // false = TPS

    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

    public Transform target;        // ����ٴ� Ÿ�� ������Ʈ�� Transform

    private Transform tr;                // ī�޶� �ڽ��� Transform

    void Start()
    {
        tr = GetComponent<Transform>();
    }


    public float cameraSpeed = 5.0f;
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2, -2);

    void Update()
    {
        if (view == true)
        {
        MouseRotation();
        KeyboardMove();
        }
        if (Input.GetKey(KeyCode.Q) && view == true)
        {
            Debug.Log("�����̽�");
                view = false;
                transform.position = new Vector3(300, 100, 300);
        }
        if (Input.GetKey(KeyCode.E) && view == false)
        {
            Debug.Log("�����̽�");
            view = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (view == true)
        {
            transform.position = player.transform.position + offset;
        }

        if (view == false)
        {
            tr.position = new Vector3(target.position.x - 0.52f, tr.position.y, target.position.z - 6.56f);
            tr.LookAt(target);
        }
    }

    void MouseRotation()
    {

        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;

        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;

        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(0, yRotate, 0);
    }

    // Ű������ ������ ���� �̵�
    void KeyboardMove()
    {
        // WASD Ű �Ǵ� ȭ��ǥŰ�� �̵����� ����
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // �̵����� * �ӵ� * �����Ӵ��� �ð��� ���ؼ� ī�޶��� Ʈ�������� �̵�
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}