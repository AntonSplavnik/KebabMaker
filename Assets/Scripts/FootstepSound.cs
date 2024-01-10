using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayFootstep();
        }
        else
            footstep.Stop();
    }
    void PlayFootstep()
    {
        if (!footstep.isPlaying)
        {
            footstep.Play();
        }
    }
}
