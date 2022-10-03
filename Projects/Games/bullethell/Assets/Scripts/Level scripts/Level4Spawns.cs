using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4Spawns : LevelBaseScript
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;


    int ListIndex = 0;
    List<LevelEvent> level1 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        Level4Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level4Setup()
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
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current.type.ToString(), current.number);
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

   

}
