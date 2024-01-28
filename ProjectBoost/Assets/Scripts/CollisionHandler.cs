using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Failure;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    AudioSource audioSrc;
    bool isTransitioning = false;
    bool collisionDisable = false;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update(){
        RespondToDebugKeys();
    }

    void RespondToDebugKeys(){
        if(Input.GetKeyDown(KeyCode.L)){
            NextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C)){
            collisionDisable = !collisionDisable; //toggle collision
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || collisionDisable) { return;} 
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
        crashParticles.Play();
        Invoke("ReloadLevel", delay);
    }
    void AdvanceLevelSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        PlaySound(Success);
        successParticles.Play();
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
