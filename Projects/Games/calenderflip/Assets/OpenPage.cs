using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenPage : MonoBehaviour
{
    [SerializeField]
    public float speed = 0;

    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(speed, 0, 0));
        if (speed > -130)
        {
            speed -= 0.5f; ;

        }

    }
}
