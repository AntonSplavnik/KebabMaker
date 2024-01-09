using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioSource audioSource;

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
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    
        Vector3 movementDirection = new Vector3(verticalInput, horizontalInput, 0f).normalized;
        if (movementDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
