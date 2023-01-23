using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daciaenemyssytem : MonoBehaviour
{
    public GameObject[] enemyList;
    public int nextInstance = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = GameObject.FindGameObjectsWithTag("daciaenemy");
        InvokeRepeating("DoSomething", 0, nextInstance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void DoSomething()
    {
        Debug.Log("Doing something!");
        nextInstance = Random.Range(1, 4);
        int numberofenemies = Random.Range(1, 6);



        for (int i = 0; i < numberofenemies; i++)
        {
            int tempEnemy = Random.Range(0, enemyList.Length);
            GameObject p = enemyList[tempEnemy];
            p.GetComponent<daciascript>().spawn(nextInstance);
        }



    }
}
