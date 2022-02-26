using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour

{
    private BoxCollider area;  

    Vector3[] positions = new Vector3[5];

    public GameObject enemy;

    public bool isSpawn = false;

    public float spawnDelay = 1.5f;

    float spawnTimer = 0f;


    // Use this for initialization

    void Start()
    {
        area = GetComponent<BoxCollider>();
        CreatePositions();
        area.enabled = false;
    }

    void CreatePositions() // 적이 나오는 지점을 카메라의 월드좌표로 정의한다

    {
        float viewPosY = 1.2f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;



        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);
            WorldPos.z = 0f;
            positions[i] = WorldPos;

        }

    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, 0, posZ);

        return spawnPos;
    }

    void SpawnEnemy()//isSpawn이 true일때 적을 랜덤하게 생성
    {

        Vector3 spawnPos = GetRandomPosition();

        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);

                Instantiate(enemy, spawnPos, Quaternion.identity);

                spawnTimer = 0f;
            }

            spawnTimer += Time.deltaTime;

        }

    }



    // Update is called once per frame

    void Update()
    {
        SpawnEnemy();
    }
}