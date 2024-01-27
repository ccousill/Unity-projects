using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer renderer;
    Rigidbody rigidBody;
    [SerializeField] float timeToWait = 3f;
    void Start()
    {
       renderer = GetComponent<MeshRenderer>();
       rigidBody = GetComponent<Rigidbody>();
       rigidBody.useGravity = false;
       renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > timeToWait){
            renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
