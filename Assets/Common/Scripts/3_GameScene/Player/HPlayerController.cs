using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public HSpawnManager spawnManager;

    void Start()
    {
        
    }
    
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal") * moveSpeed /2;
        float vMove = Input.GetAxis("Vertical") * moveSpeed ;
        

        transform.Translate(new Vector3(hMove, 0, vMove) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEnter();
    }
}
