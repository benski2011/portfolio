using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level10Spawns : LevelBaseScript
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;


    int ListIndex = 0;
    List<LevelEvent> level10 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        Level10Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level10Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 10");

        //StartCoroutine(startuptext());
        

        level10.Add(new LevelEvent(levelEventType.text, v1: "Major! Eight divisions of federation troops were speed spotted coming in our direction.", v2: "visha"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "Why?!", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "Did the commies figure out our plans? Or do we have a leak in our intel?", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.wait, 0, 1));

        level10.Add(new LevelEvent(levelEventType.text, v1: "Men! We are not allowed to retreat from this battle! We will crush these commies!", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "For freedom!", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "Task: Achieve victory at all cost", v2: "flag"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "Massive waves of incoming air units are approaching.", v2: "observer"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "We need to cancel their city tour.", v2: "tanya"));
        //level10.Add(new LevelEvent(levelEventType.text, v1: "Spawn dudes on broom and fighter planes", v2: "visha"));
        //level10.Add(new LevelEvent(levelEventType.text, v1: "SPAWN MARY LASER", v2: "visha"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "HER AGAIN?!", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "YOU KILLED MY FATHER! PREPARE TO DIE!", v2: "MaryMad"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "What's With This Sassy Lost Child?", v2: "tanya"));
        level10.Add(new LevelEvent(levelEventType.text, v1: "Task: Achieve victory at all cost", v2: "flag"));

        //level10.Add(new LevelEvent(levelEventType.text, v1: "God fight ? God speaks when Mary is beaten?", v2: "visha"));


        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level10.Add(new LevelEvent(levelEventType.enemy1, 1));
        level10.Add(new LevelEvent(levelEventType.stop));


        level10.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level10.Add(new LevelEvent(levelEventType.enemy1, 1));
        level10.Add(new LevelEvent(levelEventType.stop));
        level10.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level10.Add(new LevelEvent(levelEventType.enemy3, 1));
        level10.Add(new LevelEvent(levelEventType.stop));
        level10.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level10.Add(new LevelEvent(levelEventType.enemy2, 1));
        level10.Add(new LevelEvent(levelEventType.stop));

        level10.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        //level1.Add(new LevelEvent(levelEventType.end));



    }


    // Update is called once per frame
    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level10[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {
                
                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager10>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager10>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager10>().Spawn(current.type.ToString(), current.number);
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
