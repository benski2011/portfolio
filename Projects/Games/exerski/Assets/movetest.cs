using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour
{
    public Vector3 goal;
    public float speed = 10f;
    Rigidbody r;
    public GameObject node;
    List<Transform> nodes = new List<Transform>();

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in node.transform)
            nodes.Add(child);
        Debug.Log("added: " + nodes.Count);
        r = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //magnitude
        Vector3 position = Vector3.MoveTowards(r.position, nodes[i].position, speed * Time.fixedDeltaTime);
        position.y = this.gameObject.transform.position.y;
        r.MovePosition(position);

        if ((Mathf.Abs(nodes[i].position.x - r.position.x) < 1) && (Mathf.Abs(nodes[i].position.z - r.position.z) < 1))
        {
            //Debug.Log(i);
            i++;
            if (i >= nodes.Count)
            {
                i = 0;
            }
        }

    }
}
