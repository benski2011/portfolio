using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playbutton : MonoBehaviour
{
    public GameObject gameinfo;
    public GameObject menu;

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        gameinfo.SetActive(true);
        menu.SetActive(false);

    }
}
