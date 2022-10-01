using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testrot : MonoBehaviour
{
    private GameObject node;

    [SerializeField]
    private List<Transform> nodes = new List<Transform>();
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        node = transform.parent.GetComponent<StaveController>().node;

        foreach (Transform child in node.transform)
            if (child.gameObject.activeInHierarchy)
            {

                nodes.Add(child);

            }
    }

    // Update is called once per frame
    void Update()
    {
        index = transform.parent.GetComponent<StaveController>().index;
        
        
        Vector3 relativePos = nodes[index].transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        rotation.x = 0;

        //Debug.Log("roty: "+ rotation.y);

        //transform.rotation = rotation;


    }
}
