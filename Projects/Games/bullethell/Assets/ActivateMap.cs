using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMap : MonoBehaviour
{
    static public bool mapmenu = false;
    public GameObject playbutotn;
    // Start is called before the first frame update
    void Start()
    {
        if (mapmenu)
        {
            playbutotn.GetComponent<playbutton>().TaskOnClick();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
