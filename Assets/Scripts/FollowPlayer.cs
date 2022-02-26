using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public bool view = true; // true = 탑뷰
                            // false = TPS

    public float turnSpeed = 4.0f; // 마우스 회전 속도
    public float moveSpeed = 2.0f; // 이동 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    public Transform target;        // 따라다닐 타겟 오브젝트의 Transform

    private Transform tr;                // 카메라 자신의 Transform

    void Start()
    {
        tr = GetComponent<Transform>();
    }

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
            Debug.Log("스페이스");
                view = false;
                transform.position = new Vector3(300, 100, 300);
        }
        if (Input.GetKey(KeyCode.E) && view == false)
        {
            Debug.Log("스페이스");
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

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    // 키보드의 눌림에 따라 이동
    void KeyboardMove()
    {
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}