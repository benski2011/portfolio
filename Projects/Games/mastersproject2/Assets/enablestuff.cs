using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enablestuff : MonoBehaviour
{
    public GameObject bt;
    public GameObject meny;

    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


        bt.SetActive(active);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        active = !active;
        bt.SetActive(active);

        if (active)
        {
            meny.SetActive(false);
        }

    }
}
