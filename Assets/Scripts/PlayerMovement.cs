using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float rotationSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        audioSource.Play();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();
        // transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        //
        // if (movement != Vector2.zero)
        //     transform.forward = movement;

        rb.position += movement * moveSpeed * Time.deltaTime;

        if (movement != Vector2.zero)
        {
            // Calculate the rotation angle based on the movement direction
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            // Create a rotation quaternion
            Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            // float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            // rb.rotation = angle;
        }
        
        // rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        // Vector3 movementDirection = new Vector3(verticalInput, horizontalInput, 0f).normalized;
        // if (movementDirection != Vector3.zero)
        // {
        //     float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // }
    }
}
