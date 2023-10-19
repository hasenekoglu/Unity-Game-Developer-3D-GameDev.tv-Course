using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;

    bool İsAlive;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            ApllyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApllyRotation(-rotationThrust);
        }
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

        }
        else
        {
            audioSource.Stop();
        }


    }
    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over 
    }

}
