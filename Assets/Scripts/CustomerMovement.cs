using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject goal;
    Vector3 direction;
    

    void LateUpdate()
    {
        // magnitude это гипотенуза (теорема пифагора) - так рассчитывается расстояние между векторами
        // .normalized меняет координаты чтобы гипотенуза была равна 1. например (3, 0, 4) -> (0,6, 0, 08)
        direction = goal.transform.position - transform.position;
        transform.right = direction.normalized;
        if (direction.magnitude > 0.5)
            transform.position = transform.position + direction.normalized * moveSpeed * Time.deltaTime;
    }
}
