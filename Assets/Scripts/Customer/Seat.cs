using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool isOccupied = false;

    public void OccupySeat()
    {
        isOccupied = true;
    }
}
