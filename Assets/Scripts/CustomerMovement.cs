using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement1 : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    public GameObject sittingCustomer;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("PlayAnimation", 5f);
    }

    void PlayAnimation()
    {
        // Trigger the "YourAnimation" animation
        animator.SetTrigger("YourAnimation");
    }

    void OnAnimationEnd()
    {
        customer.SetActive(false);
        sittingCustomer.SetActive(true);
    }
}
