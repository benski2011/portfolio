using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 startpos= Vector3.zero;
    public Vector3 endpos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
    }
}
