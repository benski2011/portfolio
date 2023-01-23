using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daciascript : MonoBehaviour
{
    public int distance = 1;
    scoretracking sc;
    public bool alive = false;
    public int i;
    public float speed = 1.0f;

    Vector3 rotationGoal;

    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.Find("scoresystem").GetComponent<scoretracking>();
        rotationGoal = new Vector3(-110, 15, 0);
        Vector3 rotationToAdd = new Vector3(-110, 15, 0);
        this.transform.localRotation = Quaternion.Euler(rotationToAdd);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (daciagamestart.GameStart)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rotationGoal), speed * Time.deltaTime);

        }
        // float singleStep = speed;
        // Vector3 rotationGoal2 = Vector3.RotateTowards(transform.forward, rotationGoal, singleStep, 0.0f);
        // transform.localRotation = Quaternion.LookRotation(rotationGoal2);

        //Vector3 rotationToAdd = rotationGoal;

        //this.transform.localRotation = Quaternion.Euler(rotationToAdd);
    }

    internal void die()
    {
        if (alive)
        {
            sc.updateScore(100 * distance);
        }
        
        alive = false;
        rotationGoal = new Vector3(-110, 15, 0);
        //Vector3 rotationToAdd = new Vector3(-110, 15, 0);

        //this.transform.localRotation = Quaternion.Euler(rotationToAdd);
    }

    internal void spawn(int nextInstance)
    {
        alive = true;
        rotationGoal = new Vector3(0, 15, 0);

        //Vector3 rotationToAdd = new Vector3(0, 15, 0);

        //this.transform.localRotation = Quaternion.Euler(rotationToAdd);

        StartCoroutine(ExampleCoroutine(nextInstance));

    }

    IEnumerator ExampleCoroutine(int nextInstance)
    {
        Debug.Log("timed out");
        yield return new WaitForSeconds(nextInstance);
        rotationGoal = new Vector3(-110, 15, 0);

        //this.transform.localRotation = Quaternion.Euler(rotationToAdd);
        alive = false;

    }
}
