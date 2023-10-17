using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEditor.Callbacks;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = .5f;
    Rigidbody rigiBbody;
    void OnCollisionEnter(Collision other)
    {
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
        //to do add SFX

        rigiBbody = GetComponent<Rigidbody>();
        rigiBbody.freezeRotation = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        //to do add SFX upon crash and particle effect
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);

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

    private void ReloadLevel()
    {
        int currentSceneIndex;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
