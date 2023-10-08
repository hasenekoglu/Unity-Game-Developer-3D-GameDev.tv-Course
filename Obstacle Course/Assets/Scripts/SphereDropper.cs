using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDropper : MonoBehaviour
{
    [SerializeField] float dropSpeed = -10f;
    public GameObject[] gameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Rigidbody rb = gameObjects[i].GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.velocity = new Vector3(0, dropSpeed, 0);
            }
    }

}