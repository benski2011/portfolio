using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    TextMeshProUGUI text;

    GameObject menu;

    public float time = 60;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        int temp = (int)time;
        text.text = temp.ToString();
    }

    public void resettimer()
    {
        time = 60;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (daciagamestart.GameStart)
        {


            time -= Time.deltaTime;
            int temp = (int)time;
            if (temp >= 0)
            {
                text.text = temp.ToString();

            }
            else
            {
                daciagamestart.GameStart = false;
                menu.SetActive(true);
            }
        }
    }
}
