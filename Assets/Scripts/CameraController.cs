using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;
    }
}