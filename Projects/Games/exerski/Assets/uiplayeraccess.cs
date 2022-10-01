using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiplayeraccess : MonoBehaviour
{
    public GameObject player; 

    public StaveController contorller;




    // Start is called before the first frame update
    void Start()
    {
        contorller = player.GetComponent<StaveController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
