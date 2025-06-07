
using System;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }
}
