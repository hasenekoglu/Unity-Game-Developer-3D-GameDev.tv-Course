using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEditor.Callbacks;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = .5f;
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip crashClip;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    Rigidbody rigiBbody;
    AudioSource audioSource;

    bool successLevel;
    bool collisionDisabled = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


    }
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            CollisionToggle();
        }
    }



    void OnCollisionEnter(Collision other)
    {
        if (collisionDisabled)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":

                Debug.Log("This is friendly");
                break;

            case "Finish":

                StartSuccessSequence();
                break;

            case "Fuel":

                Debug.Log("This is fuel");
                break;

            default:
                StartCrashSequence();
                break;


        }
    }

    void StartSuccessSequence()
    {

        successLevel = true;
        rigiBbody = GetComponent<Rigidbody>();
        rigiBbody.freezeRotation = true;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successClip);
        successParticle.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        //to do add SFX upon crash and particle effect
        if (!successLevel)
        {

            GetComponent<Movement>().enabled = false;
            audioSource.Stop();
            audioSource.PlayOneShot(crashClip);
            crashParticle.Play();
            Invoke("ReloadLevel", levelLoadDelay);

        }

    }
    void LoadNextLevel()
    {


        int currentSceneIndex;
        int nextSceneIndex;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        GetComponent<Movement>().enabled = false;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void CollisionToggle()
    {
        collisionDisabled = !collisionDisabled;
        if (collisionDisabled)
        {
            Debug.Log("Collision Disabled");
        }
        else
        {
            Debug.Log("Collision Enabled");
        }
        //Toggle collision
    }
}
