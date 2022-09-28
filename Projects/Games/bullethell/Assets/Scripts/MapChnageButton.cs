using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class MapChnageButton : MonoBehaviour, IPointerEnterHandler
{
    public string SceneName;
    public int mapnr = 0;
    public bool playable = false;
    public bool playableOverride = false;
    private bool mouse_over = false;
    private Button btn;

    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        playable = mapEnabler.map[mapnr];
    }
    private void Update()
    {
        if (playable || playableOverride)
        {
            ColorBlock colorVar = btn.colors;
            colorVar.highlightedColor = new Color(0, 128, 0);
            btn.colors = colorVar;
        }

        if (!playable || playableOverride)
        {
            ColorBlock colorVar = btn.colors;
            colorVar.highlightedColor = new Color(255, 0, 0);
            btn.colors = colorVar;
        }
    }


    void TaskOnClick()
    {
        if (playable || playableOverride)
        {
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene(SceneName);
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
    }

}
