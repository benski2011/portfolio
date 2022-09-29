using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject PlayerModel;
    Rigidbody PlayerRigid;

    public float PlayerSpeed = 5.0f;
    public int PlayerHp = 100;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            PlayerModel = this.transform.Find("PlayerModel").gameObject;
            PlayerRigid = PlayerModel.GetComponent<Rigidbody>();
        }
        catch (System.Exception)
        {
            Debug.Log("cant find player model/rigidobject");
            throw;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1
        PlayerRigid.velocity = new Vector3(xMove, PlayerRigid.velocity.y, zMove) * PlayerSpeed*Time.deltaTime; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("testing purposes");
            if (this.GetComponent<CustomTest>())
            {
                Debug.Log("it alread have custom test ");
                this.gameObject.GetComponent<CustomTest>().IncreaseLevel();

            }
            else
            {
                this.gameObject.AddComponent<CustomTest>();
            }
        }
    }
}
