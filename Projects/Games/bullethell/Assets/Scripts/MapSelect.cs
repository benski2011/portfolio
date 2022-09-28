using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<MoveCamera>().setMax(180);
        Camera.main.GetComponent<MoveCamera>().setMin(-180);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Camera.main.GetComponent<MoveCamera>().ResetCam();
    }
}
