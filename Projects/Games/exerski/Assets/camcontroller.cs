using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontroller : MonoBehaviour
{
    private Vector3 offsetM;
    public GameObject playpos;
    // Start is called before the first frame update
    void Start()
    {
        offsetM = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playpos.transform.position+ offsetM;
    }
}
