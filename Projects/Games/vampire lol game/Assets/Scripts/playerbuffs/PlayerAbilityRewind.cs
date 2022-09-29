using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Champion: Zillian
/// Description: On player death, rewind 
/// </summary>
public class PlayerAbilityRewind : MonoBehaviour
{
    public int ObjectLevel = 0;

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
