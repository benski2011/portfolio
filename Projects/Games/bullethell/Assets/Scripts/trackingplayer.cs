using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingplayer : MonoBehaviour
{
    public Vector2 offset;
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x+offset.x, 0, player.transform.position.z + offset.y);
    }
}
