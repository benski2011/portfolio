using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeparts : MonoBehaviour
{


    public GameObject LeftCylynder;
    public GameObject RighCylynder;
    public GameObject MiddleCylynder;

    public Renderer renderer;
    public Material currentMaterial;
    public Material newMaterialRef;


    public string type = "middle";
    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (type == "middle")
        {

            renderer = MiddleCylynder.GetComponent<Renderer>();

        }
        if (type == "right")
        {
            renderer = RighCylynder.GetComponent<Renderer>();

        }
        if (type == "left")
        {
            renderer = LeftCylynder.GetComponent<Renderer>();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        
        if (col.transform.root.tag == "bullet")
        {

            if (type == "middle")
            {
                StartCoroutine(middledamage());

            }
            if (type == "right")
            {
                StartCoroutine(rightdamage());
            }
            if (type == "left")
            {
                StartCoroutine(leftdamage());
            }

            hp--;
        }
            
        
    }



    IEnumerator leftdamage()
    {
        renderer.material = newMaterialRef;
        yield return new WaitForSeconds(0.15f);
        renderer.material = currentMaterial;

    }

    IEnumerator rightdamage()
    {
        renderer.material = newMaterialRef;
        yield return new WaitForSeconds(0.15f);
        renderer.material = currentMaterial;

    }

    IEnumerator middledamage()
    {
        renderer.material = newMaterialRef;
        yield return new WaitForSeconds(0.15f);
        renderer.material = currentMaterial;

    }
    // Update is called once per frame
    void Update()
    {
        if (hp<0)
        {
            if (type == "middle")
            {
                this.transform.root.GetComponent<planeaicontroller>().midgun = false;
                this.transform.root.GetComponent<planeaicontroller>().dead();

            }
            if (type == "right")
            {
                this.transform.root.GetComponent<planeaicontroller>().rightgun = false;

            }
            if (type == "left")
            {
                this.transform.root.GetComponent<planeaicontroller>().leftgun = false;

            }
        }
    }


}
