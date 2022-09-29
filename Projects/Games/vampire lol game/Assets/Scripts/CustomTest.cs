using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTest : MonoBehaviour
{
    public int ObjectLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("added one instance of " + this.GetType().ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void IncreaseLevel()
    {
        Debug.Log("increassed ability by: " + ObjectLevel);
        ObjectLevel++;
    }
}