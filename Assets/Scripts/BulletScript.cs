using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float mass = 10f;
    public float force = 1000;
    private float acceleration;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletDirection = transform.up;
        acceleration = force / mass;
        speed += acceleration * Time.deltaTime;
        transform.Translate(bulletDirection * speed * Time.deltaTime, Space.World);
    }
}