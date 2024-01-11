using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 direction = Vector3.left;
    
    void Update()
    {
         transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Seat"))
        {
            moveSpeed = 0f;
        }
        else if (direction == Vector3.left)
            direction = Vector3.right;
        else
            direction = Vector3.left;
    }
}
