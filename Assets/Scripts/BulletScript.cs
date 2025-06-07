using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 5f;
    private float mass = 1;
    private float force = 1;
    private float acceleration;
    private Vector3 bulletDirection; 
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        bulletDirection =  transform.up;
        acceleration = force / mass;
        speed += acceleration * 1;
    }
    void LateUpdate()
    {
        transform.Translate(bulletDirection * (speed * Time.deltaTime), Space.World);
    }
}