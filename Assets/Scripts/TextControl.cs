using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextControl : MonoBehaviour
{

    public static TextControl instance;

    public GameObject MPKey;
    public GameObject GameOverScreen;

    public bool isStart = false;


    private void Awake()
    {
        if(TextControl.instance == null)
        {
            TextControl.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MPKey.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            MPKey.SetActive(false);
            isStart = true;
        }

        Move move = GameObject.Find("Player").GetComponent<Move>();

        if (move.GameOver == true)
        {
            GameOverScreen.SetActive(true);

            if (Input.GetKey(KeyCode.T))
            {
                GameManager.score = 0;
                SceneManager.LoadScene("Title");
            }
        }
    }
}
