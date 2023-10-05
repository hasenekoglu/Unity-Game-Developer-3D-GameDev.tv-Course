using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dropper : MonoBehaviour
{

    public GameObject[] gameObjects;
    int objectIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (objectIndex < gameObjects.Length)
            {
                if (objectIndex > 0)
                {
                    Rigidbody rigidbody = gameObjects[objectIndex - 1].GetComponent<Rigidbody>();
                    rigidbody.useGravity = true;

                }
                Rigidbody currentRigidBody = gameObjects[objectIndex].GetComponent<Rigidbody>();
                currentRigidBody.useGravity = false;
                objectIndex++;
            }


            Debug.Log("çarptın");
        }

    }
}
