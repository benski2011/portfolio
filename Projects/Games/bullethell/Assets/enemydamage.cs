using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    enemyScript e;
    private void Start()
    {
        e.GetComponent<enemyScript>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
        }
    }
}
