using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public HSpawnManager spawnManager;
    public Rigidbody rd;

    private void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
        //transform.Translate(new Vector3(hMovement, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEnter();
            Debug.Log("스폰합쉬다!!");
        }
    }
}
