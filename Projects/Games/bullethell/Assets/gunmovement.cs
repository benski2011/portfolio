using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmovement : MonoBehaviour
{
    public float leftmax;
    public float rightmax;
    public Vector3 midpoint;
    public int offset = 0;

    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (daciagamestart.GameStart)
        {
            Vector3 currentpost = this.transform.position;
            float mousex = Input.mousePosition.x;
            float screenwidth = Screen.width;
            float currentlerp = Mathf.InverseLerp(leftmax, rightmax, mousex);

            currentpost.x = Mathf.Lerp(85, 125, currentlerp);

            currentpost.x = Mathf.Clamp(currentpost.x, 85, 125);
            transform.position = currentpost;
        }
       

        //Debug.Log(Input.mousePosition.x);


        //300 1100
    }
}
