using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinscript : MonoBehaviour
{
    /// <summary>
    /// rotates parent object
    /// </summary>
    public float speed = 1;
    float roty;
    Transform r;
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
        this.transform.Rotate(0, speed, 0);

    }
}
