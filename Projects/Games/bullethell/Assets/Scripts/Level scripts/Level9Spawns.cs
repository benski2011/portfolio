using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level9Spawns : LevelBaseScript
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;


    int ListIndex = 0;
    List<LevelEvent> level9 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        Level9Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level9Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 9");

        //StartCoroutine(startuptext());
       
        


    level9.Add(new LevelEvent(levelEventType.text, v1: "Men! You were all highly efficient dealing with the commies, and now it's time to see how far we can push this. ", v2: "tanya"));
        level9.Add(new LevelEvent(levelEventType.text, v1: "I hope you can show me around in your home country Serebryakov.", v2: "tanya"));
        level9.Add(new LevelEvent(levelEventType.text, v1: "Maybe another time, but there are two companies worth of mages near our position.", v2: "visha"));
        level9.Add(new LevelEvent(levelEventType.text, v1: "Buzzkillers.", v2: "tanya"));


        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level9.Add(new LevelEvent(levelEventType.enemy1, 1));
        level9.Add(new LevelEvent(levelEventType.stop));


        level9.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level9.Add(new LevelEvent(levelEventType.enemy1, 1));
        level9.Add(new LevelEvent(levelEventType.stop));
        level9.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level9.Add(new LevelEvent(levelEventType.enemy3, 1));
        level9.Add(new LevelEvent(levelEventType.stop));
        level9.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level9.Add(new LevelEvent(levelEventType.text, v1: "God give me strength.", v2: "mary"));


        //spawn mary boss fight 

        //when mary is defeated blow her up in a yellow explotion 
        level9.Add(new LevelEvent(levelEventType.text, v1: "What the hell.", v2: "tanya"));
        level9.Add(new LevelEvent(levelEventType.text, v1: "MEN! Retreat!", v2: "tanya"));

        Debug.Log("end of setup level 1");

        //level1.Add(new LevelEvent(levelEventType.end));



    }


    // Update is called once per frame
    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level9[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {
                
                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager9>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager9>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager9>().Spawn(current.type.ToString(), current.number);
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
