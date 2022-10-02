using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBaseClass : MonoBehaviour
{
    public int ObjectLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLevel()
    {
        Debug.Log("increassed ability by: " + ObjectLevel);
        ObjectLevel++;
    }
}
