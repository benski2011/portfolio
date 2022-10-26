using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Spawns : LevelBaseScript
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;
    public GameObject VoiceLineManager;
    private VoiceLinePlayer VP;


    int ListIndex = 0;
    List<LevelEvent> level2 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();
        gamemanager = GameObject.Find("GameManager");

        Level2Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level2Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 2");

        
        level2.Add(new LevelEvent(levelEventType.text, v1: "Men! We have been tasked to ensure total air superiority in our battle against Dacia.", v2: "tanya"));
        level2.Add(new LevelEvent(levelEventType.text, v1: "As this will be a live fire exercise, I recommend testing your training on these “soldiers”", v2: "tanya"));

        level2.Add(new LevelEvent(levelEventType.text, v1: "Aye aye, Commander.", v2: "visha"));
        level2.Add(new LevelEvent(levelEventType.text, v1: "It would also be a good time to test out my new upgrades from the mad doctor.", v2: "tanya"));
        //make this italic? 

        level2.Add(new LevelEvent(levelEventType.text, v1: "Task: Ensure Air superiority over Dacia.", v2: "flag"));
        


        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level2.Add(new LevelEvent(levelEventType.enemy1, 1));
        level2.Add(new LevelEvent(levelEventType.stop));


        level2.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level2.Add(new LevelEvent(levelEventType.enemy1, 1));
        level2.Add(new LevelEvent(levelEventType.stop));
        level2.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level2.Add(new LevelEvent(levelEventType.enemy3, 1));
        level2.Add(new LevelEvent(levelEventType.stop));
        level2.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level2.Add(new LevelEvent(levelEventType.enemy2, 1));
        level2.Add(new LevelEvent(levelEventType.stop));

        level2.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        //level1.Add(new LevelEvent(levelEventType.end));



    }


    // Update is called once per frame
    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level2[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {
                
                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager2>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager2>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager2>().Spawn(current.type.ToString(), current.number);
                        ListIndex++;
                        break;

                    case levelEventType.text:

                        Debug.Log("hei");
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
