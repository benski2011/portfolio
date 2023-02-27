using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Spawns : LevelBaseScript
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
    List<LevelEvent> level3 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();
        Level3Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level3Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 3");

        //StartCoroutine(startuptext());
        
        level3.Add(new LevelEvent(levelEventType.text, v1: "The northern battalion is facing heavy resistance up north. Your company will reinforce the current line.", v2: "radio"));
        level3.Add(new LevelEvent(levelEventType.text, v1: "There has also been observed bombers in the area, these are high priority targets.", v2: "radio"));


        level3.Add(new LevelEvent(levelEventType.text, v1: "Assist the Empire soldiers. Find a way to deal with the bombers.", v2: "flag"));
        
        level3.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level3.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level3.Add(new LevelEvent(levelEventType.stop));


        level3.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level3.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level3.Add(new LevelEvent(levelEventType.stop));
       
        level3.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level3.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level3.Add(new LevelEvent(levelEventType.stop));
       
        level3.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level3.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level3.Add(new LevelEvent(levelEventType.stop));


        level3.Add(new LevelEvent(levelEventType.text, v1: "Hello", v2: "tanya"));
        level3.Add(new LevelEvent(levelEventType.enemy2, 1, loc: "up"));
        level3.Add(new LevelEvent(levelEventType.stop));
        level3.Add(new LevelEvent(levelEventType.text, v1: "Goodbye", v2: "tanya"));


        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));


       
        level3.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        level3.Add(new LevelEvent(levelEventType.end));



    }


    // Update is called once per frame
    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level3[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {

                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager3>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager3>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager3>().Spawn(current);
                        ListIndex++;
                        break;

                    case levelEventType.text:
                        VP.increaseAudioTrack();
                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text, current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end");
                        mapEnabler.map[3] = true;
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
