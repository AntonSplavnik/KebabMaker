using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [SerializeField] private List<SeatController> seats; //stores all seats in an array

    private void Start()
    {
        FindEmptySeat();
    }

    private void FindEmptySeat()
    {
        //creates a list of all available seats
        var emptySeats = new List<SeatController>();
        foreach (var seat in seats)
        {
            //adds all empty seats to the list
            if (seat.isOccupied == false)
            {
                emptySeats.Add(seat);
            }
        }

        if (emptySeats.Count > 0)
        {
            //randomly selects a seats to sit at
            var rand = Random.Range(0, emptySeats.Count);
            SeatController selectedSeat = emptySeats[rand];
            selectedSeat.isOccupied = true; // Marking seat to avoid selection by others
            var dest = emptySeats[rand].transform.position;
            StartCoroutine(MoveToSeat(dest, emptySeats[rand]));
        }
        else
        {
            Debug.LogWarning("No empty seats available for the customer.");
        }
    }

    private IEnumerator MoveToSeat(Vector3 destination, SeatController seat)
    {
        var speed = 4.0f;
        var direction = seat.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation; //calculates the rotation needed to face the targeted seat
        transform.Rotate(Vector3.forward, 90f);
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        { 
            //moves towards the seat until it is in seat distance
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                //positions the game object at the seat position and rotation
                var transform1 = transform;
                var transform2 = seat.transform;
                transform1.position = transform2.position;
                transform1.rotation = transform2.rotation;
                transform.Rotate(Vector3.forward, -90f);
                seat.OccupySeat();
            }
        }
    }
}
