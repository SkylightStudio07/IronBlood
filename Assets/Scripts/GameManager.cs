using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
 {
    public static GameManager instance; 
    public Text scoreText;
    public static int score=0; 
    void Awake()
    {
        if (!instance) 
            instance = this; 
    }

    public void AddScore() //점수를 추가해주는 함수를 만들어 줍니다.
    {
        score += 1; 
        scoreText.text = "Score : " + score; 
    }

    void Start () {

    }

    void Update () {

    }
}