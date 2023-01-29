using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeparts : MonoBehaviour
{

    public string type = "middle";
    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.transform.root.tag);
        if (col.transform.root.tag == "bullet")
        {
            hp--;
        }
            
        
    }
    // Update is called once per frame
    void Update()
    {
        if (hp<0)
        {
            if (type == "middle")
            {
                this.transform.root.GetComponent<planeaicontroller>().midgun = false;
                this.transform.root.GetComponent<planeaicontroller>().dead();

            }
            if (type == "right")
            {
                this.transform.root.GetComponent<planeaicontroller>().rightgun = false;

            }
            if (type == "left")
            {
                this.transform.root.GetComponent<planeaicontroller>().leftgun = false;

            }
        }
    }


}
