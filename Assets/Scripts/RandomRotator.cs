using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    //declare variables
    public float tumble;
    private Rigidbody rb;
    //make procedure to get the hazards in the game to tumble at random
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
