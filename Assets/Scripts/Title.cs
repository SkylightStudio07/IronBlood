using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SceneToLoad = "Select";

    // �� �ε� �Լ�
    // Ÿ��Ʋ�̹Ƿ� ���� ���� �� ȣ��

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
