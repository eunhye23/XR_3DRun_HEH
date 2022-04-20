using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlotSpanwer : MonoBehaviour
{    private int initAmount = 7;    private float plotSize = 60f;    private float xPosLeft = -22f;    private float xPosRight = 22f;    private float lastZPos = -45f;    public List<GameObject> plots;    private void Start()    {        for(int i = 0; i < initAmount; i++)        {            SpawnPlot();        }    }    private void Update()    {            }    public void SpawnPlot()    {        GameObject plotLeft = plots[Random.Range(0, plots.Count)];        GameObject plotRight = plots[Random.Range(0, plots.Count)];        float zPos = lastZPos + plotSize;        Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos), plotLeft.transform.rotation);        Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));        lastZPos += plotSize;    }}
