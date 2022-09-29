using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Champion: Lucian
/// Description: Projectiles are shot in player movement direction, number is based on level
/// </summary>
public class PlayerAbilityTheCulling : MonoBehaviour
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
