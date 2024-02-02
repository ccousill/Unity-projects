using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosion;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered {this.name} by {other.gameObject.name}");
        StartCrashSequence();
    }

    void StartCrashSequence()
    {

        GetComponent<PlayerControls>().enabled = false;
        explosion.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
}
