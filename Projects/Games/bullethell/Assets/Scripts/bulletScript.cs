using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private bool arcShotType = false;
    private bool beenclose = false;
    Vector3 ep;
    int sp;
    Vector3 ap;
    public void arcShot(Vector3 arcpoint, Vector3 aipos, Vector3 endpoint, int speed)
    {
        ep = endpoint;
        sp = speed;
        ap = arcpoint;
        Vector3 pos = (arcpoint - aipos).normalized;
        arcShotType = true;
        setSpeed(pos * sp);
        
        
    }

    private void setSpeed(Vector3 vector3)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.GetComponent<Rigidbody>().AddForce(vector3);
    }

    private void FixedUpdate()
    {
       if (arcShotType && !beenclose)
       {
           if (Vector3.Distance(ap, this.transform.position) < 1f)
           {

               Vector3 pos = (ep-ap ).normalized;
               Debug.Log("close");
               setSpeed(pos * sp);
               
               beenclose = true; 
           }
       }
    }

    void OnTriggerEnter(Collider target)
    {
        

        if (target.tag == "Player")
        {
           

            target.GetComponent<PlayerController>().decreaseHP();
            Destroy(this.gameObject);
        }

        if (target.tag == "Shield")
        {
            
            target.transform.GetComponentInParent<PlayerController>().decreaseShield();
            Destroy(this.gameObject);

        }
    }
    private void OnDestroy()
    {
        arcShotType = false; 
    }
}
