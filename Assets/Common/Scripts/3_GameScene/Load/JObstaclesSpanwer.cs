using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JObstaclesSpanwer : MonoBehaviour
{    private int initAmount = 7;
    private float ObstaclesSize = 60f;
    private float xPos = 0f;
    private float lastZPos = -60f;

    public List<GameObject> obstacles;

    private void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnObstacle();
        }
    }

    private void Update()
    {    }

    public void SpawnObstacle()
    {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

        float zPos = lastZPos + ObstaclesSize;
        Instantiate(obstacle, new Vector3(xPos, 0.025f, zPos), obstacle.transform.rotation);

        lastZPos += ObstaclesSize;    }}