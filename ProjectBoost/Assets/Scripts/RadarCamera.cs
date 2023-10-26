using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCamera : MonoBehaviour
{

    private void Update()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
