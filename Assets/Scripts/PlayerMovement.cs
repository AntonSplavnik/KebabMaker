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
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }
}
