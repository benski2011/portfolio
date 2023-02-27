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
    public GameObject VoiceLineManager;
    private VoiceLinePlayer VP;


    int ListIndex = 0;
    List<LevelEvent> level4 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();

        Level4Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level4Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 4");


        level4.Add(new LevelEvent(levelEventType.text, v1: "Objective: Take out the guns stationed in the Orse fjord. Expect heavy enemy forces.", v2: "flag"));


        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level4.Add(new LevelEvent(levelEventType.enemy1, 1));
        level4.Add(new LevelEvent(levelEventType.stop));
             
             
        level4.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level4.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level4.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level4.Add(new LevelEvent(levelEventType.stop));
             
        level4.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level4.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level4.Add(new LevelEvent(levelEventType.stop));
             
        level4.Add(new LevelEvent(levelEventType.text, v1: "More enemy soldiers spotted, incoming counter attack.", v2: "visha"));
        level4.Add(new LevelEvent(levelEventType.text, v1: "Fight with all you got men, these guns must be silenced.", v2: "tanya"));
             
        level4.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level4.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level4.Add(new LevelEvent(levelEventType.stop));


        level4.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level4.Add(new LevelEvent(levelEventType.text, v1: "WHAT IS SHE DOING HERE, ATTACK!", v2: "sueboss_mad"));
        level4.Add(new LevelEvent(levelEventType.enemy2, 1, loc: "up"));

        level4.Add(new LevelEvent(levelEventType.stop));

        // noe om at han dauer

        level4.Add(new LevelEvent(levelEventType.wait, 0, 4));

        level4.Add(new LevelEvent(levelEventType.end));



    }

    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level4[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {

                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager4>().Spawn(current);
                        ListIndex++;
                        break;

                    case levelEventType.text:
                        VP.increaseAudioTrack();
                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text, current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end");
                        mapEnabler.map[4] = true;
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
