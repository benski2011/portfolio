using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killall : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        Destroy(other.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);

    }

}
