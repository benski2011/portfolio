using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playbutton : MonoBehaviour
{
    public GameObject MapSelect;
    public GameObject startmenu;

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        Debug.Log("You have clicked the button!");
        MapSelect.SetActive(true);
        if (startmenu)
        {
            startmenu.SetActive(false);
        }
        

    }
}
