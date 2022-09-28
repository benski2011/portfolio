using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum levelEventType { wait, enemy1, enemy2, enemy3, stop, end, text};
public enum imgtype { tanya, command };

public struct LevelEvent
{
    public LevelEvent(levelEventType s, int i = 0, int j =0, string v1 = "", string v2 = "")
    {
        type = s;
        number = i;
        secounds = j;
        text = v1;
        img = v2;

    }

  // public LevelEvent(levelEventType s, string x, string y)
  // {
  //     type = s;
  //     text = x;
  //     img = y;
  // }
  //
    public levelEventType type;
    public int number;
    public int secounds;

    public string text;
    public string img;

}
public class Level1Spawns : MonoBehaviour
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;


    public int NumberOfEnemies = 0;
    int ListIndex = 0;
    List<LevelEvent> level1 = new List<LevelEvent>();
    internal float time = 0f;
    bool lvlstart = true;
    public bool waitForText = false;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        Level1Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level1Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 1");

        //StartCoroutine(startuptext());
        level1.Add(new LevelEvent(levelEventType.text, v1: "Commander, you have been tasked to take out the enemy main bomber," +
            " but to get there you need to take out the enemy mages.", v2: "visha"));
        level1.Add(new LevelEvent(levelEventType.text, v1: "This should be an walk in the park.", v2: "tanya"));
        level1.Add(new LevelEvent(levelEventType.text, v1: "Incoming!", v2: "visha"));
        level1.Add(new LevelEvent(levelEventType.text, v1: "Objectives:\n-Kill all enemy mages.\n-Take out the enemy bomber." +
            "\n-Survive. \n\nGood luck, White silver.", v2: "flag"));

        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level1.Add(new LevelEvent(levelEventType.enemy1, 1));
        level1.Add(new LevelEvent(levelEventType.stop));


        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level1.Add(new LevelEvent(levelEventType.enemy1, 1));
        level1.Add(new LevelEvent(levelEventType.stop));
        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level1.Add(new LevelEvent(levelEventType.enemy3, 1));
        level1.Add(new LevelEvent(levelEventType.stop));
        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level1.Add(new LevelEvent(levelEventType.enemy2, 1));
        level1.Add(new LevelEvent(levelEventType.stop));

        level1.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        //level1.Add(new LevelEvent(levelEventType.end));



    }


    // Update is called once per frame
    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level1[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {
                
                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;

                    case levelEventType.text:
                        
                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text,current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end"); this.GetComponent<GameManager>().endGame(); mapEnabler.map[1] = true;
                        break;

                    case levelEventType.stop: if (NumberOfEnemies == 0) { ListIndex++; } break;
                    default:
                        break;
                }


            }

        }
        

    }

    private void NextStep()
    {
        
    }

    IEnumerator startuptext()
    {

        string inc = "";

        string one = "Commander, you have been tasked to take out the enemy main bomber, but to get there you need to take out the enemy mages.";
        string two = "This should be an walk in the park.";
        string three = "Incoming!";

        talkingImage.GetComponent<Image>().sprite = vishaimg;
        for (int i = 0; i < one.Length; i++)
        {
            inc+= one[i];
            textUi.GetComponent<TMPro.TextMeshProUGUI>().text = inc;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);
        talkingImage.GetComponent<Image>().sprite = tanyaimg;

        inc = "";
        for (int i = 0; i < two.Length; i++)
        {
            inc += two[i];
            textUi.GetComponent<TMPro.TextMeshProUGUI>().text = inc;
            yield return new WaitForSeconds(0.02f);
        }
        inc = "";

        yield return new WaitForSeconds(2f);
        talkingImage.GetComponent<Image>().sprite = vishaimg;

        for (int i = 0; i < three.Length; i++)
        {
            inc += three[i];
            textUi.GetComponent<TMPro.TextMeshProUGUI>().text = inc;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);
        talkingImage.GetComponent<Image>().sprite = flagimg;

        textUi.GetComponent<TMPro.TextMeshProUGUI>().text = "Objectives:\n-Kill all enemy mages.\n-Take out the enemy bomber." +
            "\n-Survive. \n\nGood luck White silver.";

        lvlstart = true;
        time = 0;
        
    }

}
