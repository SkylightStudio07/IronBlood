using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SceneToLoad = "Select";

    // 신 로드 함수
    // 타이틀이므로 진영 선택 씬 호출

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
