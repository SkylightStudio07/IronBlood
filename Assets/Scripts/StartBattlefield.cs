using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattlefield : MonoBehaviour
{

    public GameObject Player0;
    public GameObject Player1;
    public GameObject Player2;


    public int PlayerNum = Select.Num;

    public void StartGame()
    {
        if (PlayerNum == 0) {
            Instantiate(Player0);
        }
        if (PlayerNum == 2) {
            Instantiate(Player2);
        }
    }
}
