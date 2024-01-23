using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCustomers : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Call the SpawnObject function
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
