using System;
using UnityEngine;

public class Orders : MonoBehaviour
{
    [SerializeField] GameObject sticker;

    private void FixedUpdate()
    {
        sticker.transform.position = sticker.transform.position + new Vector3(150f * Time.deltaTime, 0f, 0f);
        if (sticker.transform.position.x > 1200)
            sticker.transform.position = new Vector3(-150f, sticker.transform.position.y, 0f);
    }
}
