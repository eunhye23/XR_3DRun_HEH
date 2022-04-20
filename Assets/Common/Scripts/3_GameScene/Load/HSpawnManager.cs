using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSpawnManager : MonoBehaviour
{
    HRoadSpawn roadSpawn;
    JPlotSpanwer plotSpawner;
    JObstaclesSpanwer obstaclesSpawner;

    void Start()
    {
        roadSpawn = GetComponent<HRoadSpawn>();
        plotSpawner = GetComponent<JPlotSpanwer>();
        obstaclesSpawner = GetComponent<JObstaclesSpanwer>();
    }

   
    void Update()
    {
        
    }

    public void SpawnTriggerEnter()
    {
        roadSpawn.MoveRoad();
        plotSpawner.SpawnPlot();
        obstaclesSpawner.SpawnObstacle();
    }
}
