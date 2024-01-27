using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float upThrustPower = 1000f;
    [SerializeField] float rotationThrustPower = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        ProcessPower();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * upThrustPower * Time.deltaTime);
        }
        
    }
    void ProcessRotation(){
        if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-1);
        }
        else if(Input.GetKey(KeyCode.A)){
            ApplyRotation(1);
        }
    }

    private void ApplyRotation(int direction)
    {
        rb.freezeRotation = true; // freezing rotating to rotate
        transform.Rotate(direction * Vector3.forward * rotationThrustPower * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation
    }

    void ProcessPower(){
        if(Input.GetKey(KeyCode.W)){
            upThrustPower++;
            Debug.Log("increase power to " + upThrustPower);
        }
        else if(Input.GetKey(KeyCode.S)){
            if(upThrustPower > 1){
                upThrustPower--;
                 Debug.Log("decrease power to " + upThrustPower);
            }
        }
    }
}
