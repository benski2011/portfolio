using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        PlayerModel = this.transform.Find("PlayerModel").gameObject;
        PlayerRigid = PlayerModel.GetComponent<Rigidbody>();

       

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
        PlayerRigid.velocity = new Vector3(xMove, PlayerRigid.velocity.y, zMove) * PlayerSpeed; 
        // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("testing purposes");

            this.GetComponent<AbilitySystem>().NewAbility();

           //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\bensk\Documents\git\portfolio\Projects\Games\vampire lol game\Assets\Scripts\playerbuffs");
           //FileInfo[] info = dir.GetFiles("*.cs");
           //foreach (FileInfo f in info)
           //{
           //    string ability = Path.GetFileName(f.ToString());
           //    ability = ability.Substring(0, ability.Length - 3);
           //    Debug.Log(ability);
           //    this.gameObject.AddComponent(System.Type.GetType(ability));
           //
           //}
                //this.gameObject.AddComponent<PlayerAbilityAbosulteZero>();
                //this.gameObject.AddComponent<PlayerAbilityAceInTheHole>();
                //this.gameObject.AddComponent<PlayerAbilityArcanopulse>();
                //this.gameObject.AddComponent<PlayerAbilityBalefulStrike>();
                //this.gameObject.AddComponent<PlayerAbilityBarrier>();
                //this.gameObject.AddComponent<PlayerAbilityBloomingBurst>();
                //this.gameObject.AddComponent<PlayerAbilityBoomerangThrow>();
                //this.gameObject.AddComponent<PlayerAbilityBurnOut>();
                //this.gameObject.AddComponent<PlayerAbilityCellDivision>();
                //this.gameObject.AddComponent<PlayerAbilityChainOfCorruption>();
                //this.gameObject.AddComponent<PlayerAbilityCleanse>();
                //this.gameObject.AddComponent<PlayerAbilityDarkMatter>();
                //this.gameObject.AddComponent<PlayerAbilityDisintigrate>();
                //this.gameObject.AddComponent<PlayerAbilityEventHorizon>();
                //this.gameObject.AddComponent<PlayerAbilityFlameChompers>();
                //this.gameObject.AddComponent<PlayerAbilityGhost>();
                //this.gameObject.AddComponent<PlayerAbilityMakeItRain>();
                //this.gameObject.AddComponent<PlayerAbilityMoltenShield>();
                //this.gameObject.AddComponent<PlayerAbilityPersonalSpace>();
                //this.gameObject.AddComponent<PlayerAbilityRewind>();
                //this.gameObject.AddComponent<PlayerAbilityShockwave>();
                //this.gameObject.AddComponent<PlayerAbilityTheCulling>();
                //this.gameObject.AddComponent<PlayerAbilityTravlersCall>();
                //this.gameObject.AddComponent<PlayerAbilityZap>();

            
        }
    }
}
