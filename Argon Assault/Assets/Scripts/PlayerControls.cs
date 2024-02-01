using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float postitionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] GameObject[] lasers;
    float yThrow;
    float xThrow;
    void Start()
    {
        
    }

    void OnEnable() {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable() {
        movement.Disable();   
        fire.Disable(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessRotation()
    {
        float pitchDueToPostition = transform.localPosition.y * postitionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch =  pitchDueToPostition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        //new input system
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;


        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float newYPost = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPost, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        //old system
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // Debug.Log(horizontalThrow);
        // float verticalThrow = Input.GetAxis("Vertical");
        // Debug.Log(verticalThrow);
    }

    void ProcessFiring(){
        //push fire button
        if(fire.ReadValue<float>() > .5){
            ActivateLasers();
        }else{
            DeactivateLasers();
        }
    }

    private void DeactivateLasers()
    {
        foreach(GameObject laser in lasers){
          laser.SetActive(false);
       } 
    }

    private void ActivateLasers()
    {
       foreach(GameObject laser in lasers){
          laser.SetActive(true);
       } 
    }
}
