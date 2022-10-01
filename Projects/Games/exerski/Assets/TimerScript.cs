using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float time = 0;
    bool HasStarted = false;

    public GameObject timer;
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = timer.GetComponent<Text>();
        txt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (HasStarted)
        {
            time += Time.deltaTime;
            time = (float)System.Math.Round(time, 2);         // value = 92.2;

            // "123.46"
            txt.text = time.ToString();
           // Debug.Log(time);
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!HasStarted)
            {
                Debug.Log("timer started");
                HasStarted = true; 
            }
            else
            {
                Debug.Log("timer ended");

                //Debug.Log(time);
                HasStarted = false; ;
            }
        }
    }

}
