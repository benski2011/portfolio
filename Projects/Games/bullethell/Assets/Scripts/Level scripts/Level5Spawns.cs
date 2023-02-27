using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Spawns : LevelBaseScript
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
    List<LevelEvent> level5 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();
        Level5Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level5Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 5");

        //StartCoroutine(startuptext());

        level5.Add(new LevelEvent(levelEventType.text, v1: "You have been tasked to run delaying action until victory has been achieved.", v2: "observer"));
        level5.Add(new LevelEvent(levelEventType.text, v1: "A soldier's job is never finished.", v2: "tanya"));
        level5.Add(new LevelEvent(levelEventType.text, v1: "Objective: Run delaying action", v2: "flag"));

        level5.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level5.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level5.Add(new LevelEvent(levelEventType.stop));
             
        level5.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level5.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level5.Add(new LevelEvent(levelEventType.stop));
             
        level5.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level5.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level5.Add(new LevelEvent(levelEventType.stop));
             
             
        level5.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level5.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level5.Add(new LevelEvent(levelEventType.stop));

        level5.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        level5.Add(new LevelEvent(levelEventType.end));



    }


    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level5[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {

                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager5>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager5>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager5>().Spawn(current);
                        ListIndex++;
                        break;

                    case levelEventType.text:
                        VP.increaseAudioTrack();
                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text, current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end");
                        mapEnabler.map[5] = true;
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