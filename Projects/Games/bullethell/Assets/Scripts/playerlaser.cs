using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlaser : MonoBehaviour
{

    void OnTriggerEnter(Collider target)
    {

        if (target.tag == "Enemy")
        {
            Debug.Log("ability increase");

            Destroy(target.gameObject,1);
        }


    }
}
