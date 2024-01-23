using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatController : MonoBehaviour
{
    //assigns occupancy status to seats
    public bool isOccupied = false;

    public bool IsSeatEmpty()
    {
        return !isOccupied;
    }
    public void OccupySeat()
    {
        isOccupied = true;
    }
}
