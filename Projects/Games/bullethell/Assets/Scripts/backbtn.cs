using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class backbtn : MonoBehaviour
{
    private Button btn;
    public GameObject mapmenu;
    public GameObject mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        mainmenu.SetActive(true);
        mapmenu.SetActive(false);
        ActivateMap.mapmenu = false;

    }
}
