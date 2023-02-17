using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level7Spawns : LevelBaseScript
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
    List<LevelEvent> level7 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();

        Level7Setup();
        

        //StartCoroutine(Spawn());
    }

    private void Level7Setup()
    {
        // enemy implies type of spawnable enemy
        //wait will make the game wait x number of sec before conitnuing 
        // stop is combined with spawn to make it possible to spawn multiple enemy types 

        //todo enums 
        Debug.Log("setup level 1");

        //StartCoroutine(startuptext());
        

        //Enemy on horses, smg boss fight 2 now with shotgun

        //Spawn some allies
        level7.Add(new LevelEvent(levelEventType.text, v1: "Multiple magical signatures detected in area 42.", v2: "radio"));
        level7.Add(new LevelEvent(levelEventType.text, v1: "Requesting permission to engage.", v2: "tanya"));
        level7.Add(new LevelEvent(levelEventType.text, v1: "Negative, wait for reinforcements", v2: "radio"));
        level7.Add(new LevelEvent(levelEventType.text, v1: "Unable to comply, if we can the dro---", v2: "tanya"));
        //GRANTZ GET SNIPED

        level7.Add(new LevelEvent(levelEventType.text, v1: "*at this point an ally of tanya that has not been added yet gets sniped*"));

        



        level7.Add(new LevelEvent(levelEventType.text, v1: "A battalion of mages, incoming!", v2: "visha"));
        level7.Add(new LevelEvent(levelEventType.text, v1: "Objective: Survive", v2: "flag"));
        //Spawn many difficult enemies on ski and horse
        //Last boss is smg dude with shotgun
        //Start with shooting a lot of shotgun bullets

        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level7.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level7.Add(new LevelEvent(levelEventType.stop));


        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level7.Add(new LevelEvent(levelEventType.enemy1, 2, loc: "up"));
        level7.Add(new LevelEvent(levelEventType.stop));


        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level7.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        level7.Add(new LevelEvent(levelEventType.stop));



        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level7.Add(new LevelEvent(levelEventType.enemy1, 2, loc: "up"));
        level7.Add(new LevelEvent(levelEventType.stop));



        //level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        //level7.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        //level7.Add(new LevelEvent(levelEventType.stop));
        //level7.Add(new LevelEvent(levelEventType.wait, 0, 2));
        //level7.Add(new LevelEvent(levelEventType.enemy1, 3, loc: "up"));
        //level7.Add(new LevelEvent(levelEventType.stop));


        level7.Add(new LevelEvent(levelEventType.text, v1: "THIS IS GODS RECCONING", v2: "sueboss_damaged"));
        level7.Add(new LevelEvent(levelEventType.enemy2, 1, loc: "up"));

        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level7.Add(new LevelEvent(levelEventType.text, v1: "SHOTGUNS!", v2: "tanya"));
        level7.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level7.Add(new LevelEvent(levelEventType.text, v1: "THIS IS A TREATY VIOLATION!", v2: "tanya"));
        level7.Add(new LevelEvent(levelEventType.wait, 0, 1));

        level7.Add(new LevelEvent(levelEventType.text, v1: "Objective: Survive", v2: "flag"));



        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level7.Add(new LevelEvent(levelEventType.stop));


        

        level7.Add(new LevelEvent(levelEventType.wait, 0, 3));
        Debug.Log("end of setup level 1");

        level7.Add(new LevelEvent(levelEventType.end));



    }

    void Update()
    {
        if (lvlstart)
        {
            time += Time.deltaTime;
            LevelEvent current = level7[ListIndex];
            timeUntilExe = current.secounds;

            if (time >= timeUntilExe && !waitForText)
            {

                time = 0;

                switch (current.type)
                {
                    case levelEventType.wait: ListIndex++; break;

                    case levelEventType.enemy1:
                        enemymanager.GetComponent<EnemyManager7>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager7>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager7>().Spawn(current);
                        ListIndex++;
                        break;

                    case levelEventType.text:

                        StartCoroutine(gamemanager.GetComponent<GameManager>().writeText(current.text, current.img));
                        ListIndex++;
                        break;
                    case levelEventType.end:
                        Debug.Log("game end");
                        mapEnabler.map[7] = true;
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