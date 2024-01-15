using TMPro;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    private Custominput _input = null;
    private Vector2 _moveVector = Vector2.zero;
    private Rigidbody2D _rb = null;
    private Vector3 targetPosition = new Vector3(20f, 0f, 0f);
    [SerializeField] AudioSource audioSource;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationSpeed = 5f;

    private void Awake()
    {
        //sticker.transform.position = new Vector2(transform.position.x, transform.position.y) + orderOffset;
        audioSource.Play();
        _input = new Custominput();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Movement.performed += OnMovementPerformed;
        _input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Movement.performed -= OnMovementPerformed;
        _input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVector * movementSpeed;
        if (_moveVector != Vector2.zero)
        {
            float angle = Mathf.Atan2(_moveVector.y, _moveVector.x) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        _moveVector = Vector2.zero;
    }
}