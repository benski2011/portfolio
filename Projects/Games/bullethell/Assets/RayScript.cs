using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.Find("Player_midpoint").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
         Vector3 direction = player.transform.position - transform.position;
         direction = direction.normalized;
        
         transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
    }
}
