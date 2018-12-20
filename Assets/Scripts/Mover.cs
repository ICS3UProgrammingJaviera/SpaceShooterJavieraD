using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    //declare varuables
    public float speed;
    private Rigidbody rb;
    //Get rigidbody component and assign it to "rb" variable. Use transform and speed to calculate and assign player's movement speed and assigning it to rigidbody component.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
