using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Failure;
    AudioSource audioSrc;
    bool isTransitioning = false;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning) { return;} 
            audioSrc.Stop();
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("friend");
                    break;
                case "Finish":
                    AdvanceLevelSequence();
                    break;
                default:
                    CrashSequence();
                    break;
            }

    }

    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        PlaySound(Failure);
        Invoke("ReloadLevel", delay);
    }
    void AdvanceLevelSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        PlaySound(Success);
        Invoke("NextLevel", delay);
    }

    void PlaySound(AudioClip clip)
    {
            audioSrc.PlayOneShot(clip);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        int count = SceneManager.sceneCountInBuildSettings;
        if (nextLevel >= count)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }
}
