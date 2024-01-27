using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.tag = "Hit"; 
            GetComponent<MeshRenderer>().material.color = new Color32(72, 29, 29, 255);
        }
    }
}
