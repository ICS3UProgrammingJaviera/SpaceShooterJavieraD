using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    //destroy any game object that ibnteracts with this game object's (the boundary's) collider
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
