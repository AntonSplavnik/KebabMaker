using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement1 : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("PlayAnimation", 5f);
    }
    
    void FixedUpdate()
    {
        customer.SetActive(true);
        
    }
    
    void PlayAnimation()
    {
        // Trigger the "YourAnimation" animation
        animator.SetTrigger("YourAnimation");
    }
}
