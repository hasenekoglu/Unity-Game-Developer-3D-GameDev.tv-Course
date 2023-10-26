using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movemnetVector;

    [SerializeField] float period = 2f;

    Vector3 startingPosition;
    public float movemnetFactor;
    void Start()
    {
        startingPosition = transform.position;

    }


    void Update()
    {
        Patrol();

    }

    private void Patrol()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;                     // continually growing over time
        const float tau = Mathf.PI * 2;                        //constant value of 6.283       
        float rawSinWave = Mathf.Sin(cycles * tau);            //going from -1 to 1

        movemnetFactor = (rawSinWave + 1f) / 2;                //recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = movemnetVector * movemnetFactor;
        transform.position = startingPosition + offset;
    }
}
