using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {

        if (target.tag == "Enemy")
        {
            Debug.Log("ability increase");

            Destroy(target.gameObject,1);
        }


    }
}
