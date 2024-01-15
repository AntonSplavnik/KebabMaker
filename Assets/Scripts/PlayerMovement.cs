using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick movementJoystick;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject goal;

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

        rb.position += movement * moveSpeed * Time.deltaTime;

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(combinedVerticalInput, combinedHorizontalInput) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            CalculateDistance();
    }

    void CalculateDistance()
    {
        double distance;
    
        distance = Math.Sqrt(Math.Pow((transform.position.x - goal.transform.position.x), 2) + Math.Pow((transform.position.y - goal.transform.position.y), 2));
        Debug.Log("distance " + distance);  
    }
}
