using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    GameObject player;

    public GameObject anim;
    Animator a;

    // Start is called before the first frame update
    void Start()
    {
        a = anim.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform.Find("Player_midpoint").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = player.transform.position - transform.position;
        //direction = direction.normalized;
        //
        //transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);

        AnimatorStateInfo stateInfo = a.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Shield")
        {
            col.gameObject.transform.parent.transform.parent.GetComponent<PlayerController>().decreaseShield(1);
        }
        if (col.tag == "Player")
        {
                col.gameObject.GetComponent<PlayerController>().decreaseHP(1);
               
        }



    }
}
