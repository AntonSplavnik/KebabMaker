using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject goal;
    private Vector3 _direction;
    

    private void LateUpdate()
    {
        // magnitude это гипотенуза (теорема пифагора) - так рассчитывается расстояние между векторами
        // .normalized меняет координаты чтобы гипотенуза была равна 1. например (3, 0, 4) -> (0.6, 0, 0.8)
        _direction = goal.transform.position - transform.position;
        //transform.right = direction.normalized;
        if (_direction.magnitude > 0.5)
            transform.position = transform.position + _direction.normalized * (moveSpeed * Time.deltaTime);
        CalculateAngle();
    }
    private void CalculateAngle()
    {
        // transform.up - upward direction
        var playerForward = transform.up;
        var goalDirection = goal.transform.position - transform.position;
        var clockwise = 1;
        
        if (Cross(playerForward, goalDirection).z < 0)
            clockwise = -1;
        var dotProduct = playerForward.x * goalDirection.x + playerForward.y * goalDirection.y;
        var angle = Mathf.Acos(dotProduct / (playerForward.magnitude * goalDirection.magnitude));
        // angle * Mathf.Rad2Deg - converts the angle from radians to degrees
        if (float.IsNaN(angle))
            return;
        transform.Rotate(0, 0, angle * Mathf.Rad2Deg * clockwise);
    }
    private static Vector3 Cross(Vector3 v, Vector3 w)
    {
        var crossProduct = new Vector3(v.y * w.z - v.z * w.y, v.z * w.x - v.x * w.z, v.x * w.y - v.y * w.x);
        return (crossProduct);
    }
}
