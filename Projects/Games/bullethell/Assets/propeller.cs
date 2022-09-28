using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propeller : MonoBehaviour
{
    public float speed;
    Transform r;
    float roty;

    // Start is called before the first frame update
    void Start()
    {
        r = this.transform;
        roty = r.transform.rotation.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        roty += speed;
        this.transform.Rotate(0, 0, speed);
         
    }
}
