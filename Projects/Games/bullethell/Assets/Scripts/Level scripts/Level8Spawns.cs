using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level8Spawns : LevelBaseScript
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
    List<LevelEvent> level8 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();

        Level8Setup();


        //StartCoroutine(Spawn());
    }

    private void Level8Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 8");

        //StartCoroutine(startuptext());

        level8.Add(new LevelEvent(levelEventType.text, v1: "MEN! Today we are attacking enemy supply depots.", v2: "tanya"));
        level8.Add(new LevelEvent(levelEventType.text, v1: "I expect you all to do your best!", v2: "tanya"));
        level8.Add(new LevelEvent(levelEventType.text, v1: "For pasta!", v2: "visha"));
        level8.Add(new LevelEvent(levelEventType.text, v1: "Lieutenant!", v2: "tanya"));



        level8.Add(new LevelEvent(levelEventType.text, v1: "Objective: Take out enemies defending hostile supply depots. Capture the pasta at all costs.", v2: "flag"));


        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy4, 3, loc: "up"));
        level8.Add(new LevelEvent(levelEventType.stop));


        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level8.Add(new LevelEvent(levelEventType.stop));
        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level8.Add(new LevelEvent(levelEventType.stop));
        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level8.Add(new LevelEvent(levelEventType.stop));

        //level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 1));
        level8.Add(new LevelEvent(levelEventType.stop));


        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 1));
        level8.Add(new LevelEvent(levelEventType.stop));
        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level8.Add(new LevelEvent(levelEventType.enemy2, 1));
        level8.Add(new LevelEvent(levelEventType.stop));


        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy2, 1));
        level8.Add(new LevelEvent(levelEventType.stop));


        level8.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level8.Add(new LevelEvent(levelEventType.enemy1, 4));
        level8.Add(new LevelEvent(levelEventType.stop));

        level8.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        level8.Add(new LevelEvent(levelEventType.end));



    }

    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level8[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {

                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager8>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager8>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager8>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy4:
                        enemymanager.GetComponent<EnemyManager8>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy5:
                        enemymanager.GetComponent<EnemyManager8>().Spawn(current);
                        ListIndex++;
                        break;


                    case levelEventType.text:
                        VP.increaseAudioTrack();
                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text, current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end");
                        mapEnabler.map[8] = true;
                        this.GetComponent<GameManager>().endGame();
                        break;

                    case levelEventType.stop: if (NumberOfEnemies == 0) { ListIndex++; } break;
                    default:
                        break;
                }


            }

        }


    }
}