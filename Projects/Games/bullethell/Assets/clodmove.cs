using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clodmove : MonoBehaviour
{
    public float endpos;
    Vector3 endposvec;
    public float startpos;
    Vector3 startposvec;

    Vector3 temp;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        endposvec = new Vector3(endpos, transform.position.y, transform.position.z);
        startposvec = new Vector3(startpos, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, endposvec, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, endposvec) < 0.001f)
        {
            temp = endposvec;
            endposvec = startposvec;
            startposvec = temp;


           
            // Swap the position of the cylinder.
        }
    }
}
