using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick movementJoystick;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    public GameObject bullet;
    public Transform gun;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Keyboard input
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        // Joystick input
        var joystickHorizontalInput = movementJoystick.Direction.x;
        var joystickVerticalInput = movementJoystick.Direction.y;

        // Combine keyboard and joystick inputs
        var combinedHorizontalInput = Mathf.Abs(joystickHorizontalInput) > 0.1f ? joystickHorizontalInput : horizontalInput;
        var combinedVerticalInput = Mathf.Abs(joystickVerticalInput) > 0.1f ? joystickVerticalInput : verticalInput;

        var movement = new Vector2(combinedHorizontalInput, combinedVerticalInput);
        movement.Normalize();

        rb.position += movement * (moveSpeed * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(combinedVerticalInput, combinedHorizontalInput) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gun.position, gun.rotation);
            Debug.Log("hello");
        }
    }


    // private void CalculateDistance()
    // {
    //     var playerPosition = goal.transform.position;
    //     var goalPosition = transform.position;
    //     var distance = Math.Sqrt(Math.Pow((goalPosition.x - playerPosition.x), 2) + Math.Pow((goalPosition.y - playerPosition.y), 2));
    //     Debug.Log("distance " + distance);  
    // }
    //
    // Vector3 Cross(Vector3 v, Vector3 w)
    // {
    //     var crossProduct = new Vector3(v.y * w.z - v.z * w.y, v.z * w.x - v.x * w.z, v.x * w.y - v.y * w.x);
    //     return (crossProduct);
    // }
    // void CalculateAngle()
    // {
    //     // transform.up - upward direction
    //     Vector3 playerForward = transform.up;
    //     Vector3 goalDirection = goal.transform.position - transform.position;
    //     var clockwise = 1;
    //     
    //     if (Cross(playerForward, goalDirection).z < 0)
    //         clockwise = -1;
    //     var dotProduct = playerForward.x * goalDirection.x + playerForward.y * goalDirection.y;
    //     var angle = Mathf.Acos(dotProduct / (playerForward.magnitude * goalDirection.magnitude));
    //     // angle * Mathf.Rad2Deg - converts the angle from radians to degrees
    //     transform.Rotate(0, 0, angle * Mathf.Rad2Deg * clockwise);
    // }
}
