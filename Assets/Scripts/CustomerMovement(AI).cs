using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject[] seats; //stores all seats in an array

    private void Start()
    {
        FindEmptySeat();
    }

    private void FindEmptySeat()
    {
        //creates a list of all available seats
        List<GameObject> emptySeats = new List<GameObject>();
        foreach (GameObject seat in seats)
        {
            //adds all empty seats to the list
            if (seat.GetComponent<SeatController>().isOccupied == false)
            {
                emptySeats.Add(seat);
            }
        }

        if (emptySeats.Count > 0)
        {
            //randomly selects a seats to sit at
            int rand = Random.Range(0, emptySeats.Count);
            Vector3 dest = emptySeats[rand].transform.position;
            StartCoroutine(MoveToSeat(dest, emptySeats[rand]));
        }
    }

    private IEnumerator MoveToSeat(Vector3 destination, GameObject seat)
    {
        float speed = 4.0f;
        Vector3 direction = seat.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation; //calculates the rotation needed to face the targeted seat
        transform.Rotate(Vector3.forward, 90f);
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        { 
            //moves towards the seat until it is in seat distance
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                //positions the gameobject at the seat position and rotation
                transform.position = seat.transform.position;
                transform.rotation = seat.transform.rotation;
                transform.Rotate(Vector3.forward, -90f);
                seat.GetComponent<SeatController>().OccupySeat();
            }
        }
    }
}
