using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedx = 0;
    [SerializeField] float speedy = .5f;
    [SerializeField] float speedz = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedx,speedy,speedz);
    }
}
