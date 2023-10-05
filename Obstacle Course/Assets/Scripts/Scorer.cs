using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    float hits = 0;
    private void OnCollisionEnter(Collision other)
    {
        hits++;
        Debug.Log(hits);
    }
}
