using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    private float maxLeft  = 0;
    private float minLeft = 0;

    Vector3 startpos; 

    private void Start()
    {
        startpos = this.transform.localPosition;
        
    }
    void Update()
    {
        movecam();

        
    }

    public void setMin(int n)
    {
        minLeft = n;

    }
    public void setMax(int n)
    {
        maxLeft = n;
    }

    private void movecam()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * -dragSpeed, 0, 0);
        if (maxLeft != 0 || minLeft != 0)
        {
            if (Camera.main.transform.localPosition.x < minLeft)
            {
                Camera.main.transform.localPosition = new Vector3(minLeft, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z);

            }
            if (Camera.main.transform.localPosition.x > maxLeft)
            {
                Camera.main.transform.localPosition = new Vector3(maxLeft, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z);

            }

            transform.Translate(move, Space.World);
        }

    }

    public void ResetCam()
    {
        this.transform.localPosition = startpos;
        maxLeft = 0;
        minLeft = 0;
    }

}
