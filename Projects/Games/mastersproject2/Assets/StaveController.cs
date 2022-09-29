using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaveController : MonoBehaviour
{

    public Vector3 goal;
    Rigidbody r;
    public GameObject node;
    List<Transform> nodes = new List<Transform>();

    public GameObject negativextest;

    public  int index = 0;

    public float testspeed = 0;

    private Rigidbody rbody;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject DecalArrow;

     int additionalForceRight = 0;
     int additionalForceLeft = 0;

    public float speedmodLeft = 1f;
    public float speedmodRight = 1f;
    public float rotationSpeed = 0.3f;
    public float heightmodifier = 2f;

    public int UpHillDownHillSpeed = 500;

    public bool wheelchair = true; 

    float RightPrevHeight;
    float RightPrevLenght;
    float LeftPrevHeight;
    float LeftPrevLenght;
    float LeftPrevX;
    float RightPrevX;

    Vector3 LeftPrevdist;
    Vector3 RightPrevdist;


    public float registerRate = 1.0f;
    float canRegister = 1f;

    bool CanTakeInput = false;
    private Quaternion rotationOffset;
    private Quaternion rotationstuff;

    private float timeCount = 0.0f;

    // Y is height
    // Z is forward/backwards
    // 0 is based on headset

    // Start is called before the first frame update
    void Start()
    {


        int x = 0;
        foreach (Transform child in node.transform)
            if (child.gameObject.activeInHierarchy)
            {
                nodes.Add(child);
                //Debug.Log("added child: " + x + "link: ", child.gameObject);
                x++;

            }
        Debug.Log("added: " + nodes.Count);

        rbody = this.GetComponent<Rigidbody>();
        RightPrevHeight = RightHand.transform.localPosition.y;
        LeftPrevHeight = LeftHand.transform.localPosition.y;
        RightPrevLenght = RightHand.transform.localPosition.z;
        LeftPrevLenght = LeftHand.transform.localPosition.z;
        RightPrevX = RightHand.transform.localPosition.x;
        LeftPrevX = LeftHand.transform.localPosition.x;



        LeftPrevdist = LeftHand.transform.position - nodes[index].transform.position;
        RightPrevdist = RightHand.transform.position - nodes[index].transform.position;



        
        r = this.GetComponent<Rigidbody>();

        StartCoroutine(WaitForInput());
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(5);
        CanTakeInput = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (wheelchair)
        {
            Vector3 tremp = nodes[index].transform.position - transform.position;
            tremp.y = 0;
           // tremp = tremp.normalized;
            Quaternion lookOnLook = Quaternion.LookRotation(tremp);



            transform.rotation = Quaternion.Lerp(transform.rotation, lookOnLook, Time.deltaTime * rotationSpeed);
        }
        if (!wheelchair)
        {
            Vector3 tremp = nodes[index].transform.position - DecalArrow.transform.position;
            tremp.y = 0;
            Quaternion lookOnLook = Quaternion.LookRotation(tremp);



            DecalArrow.transform.rotation = Quaternion.Lerp(DecalArrow.transform.rotation, lookOnLook, Time.deltaTime * rotationSpeed);
        }


        if (CanTakeInput)
        {
            PlayerMovementRightHand();
            PlayerMovementLeftHand();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Tundra", LoadSceneMode.Additive);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            r.gameObject.transform.position = nodes[index].transform.position;
        }

        //Debug.Log("lefthand: "+LeftHand.transform.localPosition);
        //Debug.Log("righthand: " + RightHand.transform.localPosition);
        //
        //
        //Vector3 relativePos = nodes[index].transform.position - transform.position;
        //rotationOffset = Quaternion.LookRotation(relativePos, Vector3.up);
        //rotationOffset.x = 0;
        //
        //rotationstuff = Quaternion.Inverse(transform.rotation) * rotationOffset;
        //
        //Vector3 temp = Quaternion.AngleAxis(rotationOffset.y, Vector3.up) * this.transform.position;

        //Vector3 relativePos = nodes[index].transform.position - transform.position;
        //
        // // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //rotation.x = 0;
        // 
        // 
        //Debug.Log("rot: " + rotationstuff.eulerAngles);
        //

        //transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, timeCount);
        //timeCount = timeCount + Time.deltaTime;

        //transform.rotation = rotation;



        //transform.rotation = rotationOffset;



    }

    private void PlayerMovementLeftHand()
    {
        //take current hand pos + angular diff and get z?
        //flip these?
       // Vector3 temp = Quaternion.Euler(1, rotationstuff.y, 1) * LeftHand.transform.localPosition;

        float Leftheight = Mathf.Abs(LeftHand.transform.localPosition.y - LeftPrevHeight);
        float LeftLenght = Mathf.Abs(LeftHand.transform.localPosition.z - LeftPrevLenght);
        //float LeftLenght = Mathf.Abs(temp.z - LeftPrevLenght);

        float LeftX = Mathf.Abs(LeftHand.transform.localPosition.x - LeftPrevX);

        if (Leftheight < 0.01f) { Leftheight = 0; }
        if (LeftLenght < 0.01f) { LeftLenght = 0; }
        if (LeftX < 0.01f) { LeftX = 0; }



        if ((LeftHand.transform.localPosition.y < LeftPrevHeight)&& Leftheight != 0)
        {
            PlayerMovement(Leftheight);
        }


        if ((LeftHand.transform.localPosition.x < LeftPrevX) && Leftheight != 0)
        {
            //PlayerMovement(LeftX);
        }

        if ((LeftHand.transform.localPosition.z < LeftPrevLenght) && LeftLenght != 0)
        {
            //PlayerMovement(LeftLenght);
        }


        //PlayerMovement(LeftLenght);

        Vector3 tempThis = LeftHand.transform.position;
        Vector3 tempNode = nodes[index].transform.position;
        tempThis.y = 0;
        tempNode.y = 0;

        Vector3 dist = tempThis - tempNode;

        if ((dist.magnitude > LeftPrevdist.magnitude))
        {
            PlayerMovement(Vector3.Distance(dist, LeftPrevdist));
        }
        LeftPrevdist = dist;

        LeftPrevHeight = LeftHand.transform.localPosition.y;
       // LeftPrevLenght = LeftHand.transform.localPosition.z;
        LeftPrevLenght = LeftHand.transform.localPosition.z;

        LeftPrevX = LeftHand.transform.localPosition.x;
    }

    private void PlayerMovementRightHand()
    {
        //Vector3 temp = Quaternion.Euler(0, rotationstuff.y, 0) * RightHand.transform.localPosition;

        float Rightheight = Mathf.Abs(RightHand.transform.localPosition.y - RightPrevHeight);
        float RightLenght = Mathf.Abs(RightHand.transform.localPosition.z - RightPrevLenght);

        Vector3 tempThis = RightHand.transform.position;
        Vector3 tempNode = nodes[index].transform.position;
        tempThis.y = 0;
        tempNode.y = 0;

        Vector3 dist = tempThis - tempNode;
        float dist2 = Vector3.Distance(tempThis, tempNode);



        //float RightLenght = Mathf.Abs(temp.z - RightPrevLenght);

        float RightX = Mathf.Abs(RightHand.transform.localPosition.x - RightPrevX);



        if (Rightheight < 0.01f) { Rightheight = 0; }
        if (RightLenght < 0.01f) { RightLenght = 0; }
        if (RightX < 0.01f) { RightX = 0; }


        if ((RightHand.transform.localPosition.y < RightPrevHeight) && Rightheight != 0)
        {
            PlayerMovementRight(Rightheight);
        }
        if ((RightHand.transform.localPosition.x < RightPrevX) && Rightheight != 0)
        {
            //PlayerMovement(RightX);
        }

       // if ((RightHand.transform.localPosition.z < RightPrevLenght) && RightLenght != 0)
       // {
       //     PlayerMovement(RightLenght);
       // }

        if ((dist.magnitude > RightPrevdist.magnitude))
        {
            PlayerMovementRight(Vector3.Distance(dist, RightPrevdist));
        }

        //Debug.Log("mag: " + Vector3.Distance(dist, RightPrevdist));

        RightPrevdist = dist;

        RightPrevHeight = RightHand.transform.localPosition.y;

        //RightPrevLenght = RightHand.transform.localPosition.z;
        RightPrevLenght = RightHand.transform.localPosition.z;

        RightPrevX = RightHand.transform.localPosition.x;
    }

    private void PlayerMovement(float f)
    {
        //r.AddForce(-Vector3.forward*(f*speedmod));


        if (f > 1.5f)
        {
            return;
        }
         goal = nodes[index].transform.position;
        
         Vector3 nextNodeDir = (nodes[index].transform.position - r.transform.position);
         nextNodeDir = nextNodeDir.normalized;
        
        
         //Debug.Log("inc f:"+f);
         //Debug.Log("nextNodeDir:" + nextNodeDir.ToString("F4"));
         //Debug.Log("speed: "+nextNodeDir * (f * speedmodLeft + additionalForce));
         r.AddForce(nextNodeDir * (f * (speedmodLeft+additionalForceLeft)));

        float s = (nextNodeDir * (f * speedmodLeft + additionalForceLeft)).magnitude;
        GraphChartFeed.leftaverage.Add(s);

    }

    private void PlayerMovementRight(float f)
    {
        //r.AddForce(-Vector3.forward*(f*speedmod));


        if (f > 1.5f)
        {
            return;
        }
        goal = nodes[index].transform.position;

        Vector3 nextNodeDir = (nodes[index].transform.position - r.transform.position);
        nextNodeDir = nextNodeDir.normalized;


        //Debug.Log("inc f:"+f);
        //Debug.Log("nextNodeDir:" + nextNodeDir.ToString("F4"));
        //Debug.Log("speed: " + nextNodeDir * (f * speedmodRight + additionalForceRight));
        r.AddForce(nextNodeDir * (f * (speedmodLeft + additionalForceRight)));

        float s = (nextNodeDir * (f * speedmodRight + additionalForceRight)).magnitude;
        GraphChartFeed.rightaverage.Add(s);
        //Debug.Log(s);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "node")
        {
            index++;
            if (index >= nodes.Count)
            {
                index = 0;
                Debug.Log("reset");


            }

            //make this a switch? 

            if (index == 0)
            {
                return;
            }
            //Debug.Log((nodes[index].transform.position.y - nodes[index - 1].transform.position.y, nodes[index - 1].transform.gameObject));

            if ((nodes[index].transform.position.y - nodes[index-1].transform.position.y ) > heightmodifier)
            {

                Debug.Log("going up");
                additionalForceRight = -UpHillDownHillSpeed;
                additionalForceLeft = -UpHillDownHillSpeed;


            }
            else if ((nodes[index].transform.position.y - nodes[index-1].transform.position.y ) < -heightmodifier)
            {
                Debug.Log("going down");
                additionalForceRight = UpHillDownHillSpeed;
                additionalForceLeft = UpHillDownHillSpeed;
            }
            else
            {
                additionalForceRight = 0;
                additionalForceLeft = 0;
            }


        }
    }

}
