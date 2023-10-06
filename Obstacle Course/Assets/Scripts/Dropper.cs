using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Dropper : MonoBehaviour
{

    public GameObject[] gameObjects;
    int currentIndex = 0;
    float triggerTime;
    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !triggered)

        {
            triggered = true;
            triggerTime = Time.time;

            BoxDropped(currentIndex);

        }

    }
    void Update()
    {
        BoxDelay();
    }

    void BoxDelay()
    {
        float delayTime = Time.time - triggerTime;
        if (triggered)
        {
            if (delayTime >= .5f)
            {
                if (currentIndex < gameObjects.Length)
                {
                    BoxDropped(currentIndex);
                    currentIndex++;
                    triggerTime = Time.time;
                }
            }
        }


    }
    void BoxDropped(int index)
    {
        if (index >= 0 && index < gameObjects.Length)
        {
            Rigidbody rb = gameObjects[index].GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }
}


