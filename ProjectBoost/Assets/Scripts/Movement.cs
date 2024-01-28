using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSrc;
    [SerializeField] float upThrustPower = 1000f;
    [SerializeField] float rotationThrustPower = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrust;
    [SerializeField] ParticleSystem leftJet;
    [SerializeField] ParticleSystem rightJet;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        ProcessPower();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateTight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            StopRotating();
        }
    }

    
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * upThrustPower * Time.deltaTime);
        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(mainEngine);
        }
        if (!mainThrust.isPlaying)
        {
            mainThrust.Play();
        }
    }

    private void StopThrusting()
    {
        mainThrust.Stop();
        audioSrc.Stop();
    }

    private void StopRotating()
    {
        leftJet.Stop();
        rightJet.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(1);
        if (!leftJet.isPlaying)
        {
            leftJet.Play();
        }
    }

    private void RotateTight()
    {
        ApplyRotation(-1);
        if (!rightJet.isPlaying)
        {
            rightJet.Play();
        }
    }

    private void ApplyRotation(int direction)
    {
        rb.freezeRotation = true; // freezing rotating to rotate
        transform.Rotate(direction * Vector3.forward * rotationThrustPower * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation
    }

    void ProcessPower()
    {
        if (Input.GetKey(KeyCode.W))
        {
            upThrustPower++;
            Debug.Log("increase power to " + upThrustPower);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (upThrustPower > 1)
            {
                upThrustPower--;
                Debug.Log("decrease power to " + upThrustPower);
            }
        }
    }
}
