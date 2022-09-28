using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player bullet script - attacks enemy
/// </summary>
public class playerbullet : MonoBehaviour
{
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {

        if (target.tag == "Enemy")
        {
            Debug.Log("ability increase");

            player.GetComponent<PlayerController>().increaseAbility();
            Destroy(this.gameObject);
        }


    }
}
