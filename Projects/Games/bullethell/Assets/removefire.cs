using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removefire : MonoBehaviour
{
    public float timer = 0.1f;
    // Start is called before the first frame update
    bool showfire = false;
    GameObject child;

    private void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    public void fire()
    {
        timer = 0.2f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer>0)
        {
            child.SetActive(true);
            
        }
        if (timer < 0)
        {
            child.SetActive(false);
        }
    }
}
