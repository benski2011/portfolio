using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notescrp : MonoBehaviour
{
    public float offsetY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow,99999);
           // Debug.Log("Did Hit");

            this.transform.position = hit.point + new Vector3(0, offsetY, 0);

            Debug.DrawLine(Vector3.zero, new Vector3(0, 50, 0), Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(transform.position, new Vector3(0, 50, 0), Color.red);

    }
}
