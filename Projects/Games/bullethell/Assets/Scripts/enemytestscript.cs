using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytestscript : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        g.GetComponent<Level1Spawns>().NumberOfEnemies--;
        Destroy(this.gameObject);
    }


}
