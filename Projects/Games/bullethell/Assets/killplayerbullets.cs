using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayerbullets : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);

        }

    }
}
