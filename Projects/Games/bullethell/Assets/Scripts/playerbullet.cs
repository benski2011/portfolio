using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player bullet script - attacks enemy
/// </summary>
public class playerbullet : MonoBehaviour
{
    public GameObject shooter;
    public string target;

    public float bulletDamage = 1;

    // Start is called before the first frame update
    public void init(GameObject sbulletShooter)
    {
        shooter = sbulletShooter;
        if (shooter.gameObject.tag == "Player")
        {
            target = "Enemy";
        }
        else
        {
            target = "Player";

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBulletDamage(int damge)
    {
        bulletDamage = damge;
    }

    void OnTriggerEnter(Collider col)
    {
        if (target == "Player" && col.tag == "Shield")
            {
            col.gameObject.transform.parent.transform.parent.GetComponent<PlayerController>().decreaseShield(1);
            Destroy(this.gameObject);
            }
        if (col.tag == target)
        {
            //apply damage to interface



            if (target == "Player")
            {
                col.gameObject.GetComponent<PlayerController>().decreaseHP(1);
                Destroy(this.gameObject);


            }
            if (target == "Enemy")
            {
                //Debug.Log(col.name);
                col.gameObject.GetComponent<EnemyBaseScript>().DecreaseHP(1);
                Destroy(this.gameObject);

            }
        }



    }

    void OnTriggerExit(Collider target)
    {

        if (target.name == "killbox")
        {
           
            Destroy(this.gameObject);
        }


    }
}
