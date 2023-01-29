using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enamblemapinfo : MonoBehaviour
{
    public GameObject gameinfo;

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        gameinfo.SetActive(true);


    }
}
