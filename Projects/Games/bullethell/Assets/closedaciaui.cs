using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closedaciaui : MonoBehaviour
{
    private Button btn;

    public GameObject menu;
    public GameObject canvas;
    public GameObject timer;
    public GameObject score;


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
        score.GetComponent<scoretracking>().daciaScore = 0;
        score.GetComponent<scoretracking>().updateScore(0);
        daciagamestart.GameStart = true;
        timer.GetComponent<timer>().resettimer();
        menu.SetActive(false);
        canvas.GetComponent<clickenemy>().resetbullets(); ;

    }
}
