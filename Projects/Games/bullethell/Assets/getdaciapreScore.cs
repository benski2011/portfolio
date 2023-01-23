using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getdaciapreScore : MonoBehaviour
{
    public GameObject sc;

    // Start is called before the first frame update
    void OnEnable()
    {
        int temp2 = sc.GetComponent<scoretracking>().daciaScore;
        TextMeshProUGUI text;

        text = GetComponent<TextMeshProUGUI>();
        string temp = temp2.ToString("D5");
        text.text = temp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
