using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoretracking : MonoBehaviour
{
    TextMeshProUGUI text;
    public int daciaScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        daciaScore = 0;
        text = GetComponent<TextMeshProUGUI>();
        string temp = daciaScore.ToString("D5");
        text.text = temp.ToString();

    }

    // Update is called once per frame
    void Update()
    {
       // daciagamestart.DaciaHighscore = daciaScore;
       // daciagamestart.DaciaPrevScore = daciaScore;
    }

    public void updateScore(int sc)
    {
        daciaScore += sc;
        string temp = daciaScore.ToString("D5");
        text.text = temp.ToString();
        if (daciaScore > daciagamestart.DaciaHighscore)
        {
            daciagamestart.DaciaHighscore = daciaScore;
        }

    }
}
