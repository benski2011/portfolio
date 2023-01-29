using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitmapinfo : MonoBehaviour
{
    public GameObject gameinfo;

    void Start()
    {
        gameinfo = gameObject.transform.parent.gameObject;
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        gameinfo.SetActive(false);


    }
}
