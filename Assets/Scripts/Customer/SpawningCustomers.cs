using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCustomers : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public int maxCustomers = 7;
    private int spawned = 0;
    
    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (spawned > maxCustomers)
            {
                Debug.Log("Max number of customers reached");
                return;                
            }
            else
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                spawned++;    
            }
        }
    }
}
