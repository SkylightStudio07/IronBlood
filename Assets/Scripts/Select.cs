using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Select : MonoBehaviour
{

    bool bTurnLeft = false;
    bool bTurnRight = false;
    private Quaternion turn = Quaternion.identity;

    public static int Num = 0;
    int value = 0;

    // Use this for initialization
    void Start()
    {
        turn.eulerAngles = new Vector3(0, value, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bTurnLeft)
        {
            Debug.Log("Left");
            Num++;
            if (Num == 3)
                Num = 0;
            Debug.Log(Num);
            value -= 120;

            bTurnLeft = false;

        }
        if (bTurnRight)
        {
            Debug.Log("Right");
            Num--;
            if (Num == -1)
                Num = 2;
            Debug.Log(Num);
            value += 120;

            bTurnRight = false;

        }
        turn.eulerAngles = new Vector3(0, value, 0);
        // ������ ����
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * 5.0f);
        // ȸ��
    }

    public void turnLeft()
    {
        bTurnLeft = true;
        bTurnRight = false;
    }

    public void turnRight()
    {
        bTurnRight = true;
        bTurnLeft = false;
    }

    public void turnStage()
    {
        // �������� ��ȯ�� ���� �Լ�
        if (Num == 2)
        {
            SceneManager.LoadScene("Battlefield2");
        }
        if (Num == 0)
        {
            SceneManager.LoadScene("Battlefield3");
        }
    }

}
