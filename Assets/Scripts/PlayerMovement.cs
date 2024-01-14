using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick movementJoystick;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Joystick input
        float joystickHorizontalInput = movementJoystick.Direction.x;
        float joystickVerticalInput = movementJoystick.Direction.y;

        // Combine keyboard and joystick inputs
        float combinedHorizontalInput = Mathf.Abs(joystickHorizontalInput) > 0.1f ? joystickHorizontalInput : horizontalInput;
        float combinedVerticalInput = Mathf.Abs(joystickVerticalInput) > 0.1f ? joystickVerticalInput : verticalInput;

        Vector2 movement = new Vector2(combinedHorizontalInput, combinedVerticalInput);
        movement.Normalize();

        rb.position += movement * moveSpeed * Time.deltaTime;

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(combinedVerticalInput, combinedHorizontalInput) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
