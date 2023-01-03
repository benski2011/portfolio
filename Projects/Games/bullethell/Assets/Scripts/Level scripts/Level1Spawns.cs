using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum levelEventType { wait, enemy1, enemy2, enemy3, stop, end, text, special};
public enum imgtype { tanya, command };

/// <summary>
/// level 1 script info
/// </summary>
public struct LevelEvent
{

    //todo move this shit to its own file 
    public LevelEvent(levelEventType s, int i = 0, int j =0, string loc = "", string v1 = "", string v2 = "")
    {
        type = s;
        number = i;
        secounds = j;
        text = v1;
        img = v2;
        location = loc;

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
    public string location;

}
public class Level1Spawns : LevelBaseScript
{

    public GameObject enemymanager;
    public GameObject textUi;
    public GameObject talkingImage;
    public GameObject gamemanager;


    public GameObject VoiceLineManager;
    private VoiceLinePlayer VP;


    int ListIndex = 0;
    List<LevelEvent> level1 = new List<LevelEvent>();
    bool lvlstart = true;
    float timeUntilExe = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        VP = VoiceLineManager.GetComponent<VoiceLinePlayer>();

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

        level1.Add(new LevelEvent(levelEventType.text, v1: "The Entente Alliance has violated our borders. " +
            "Fairy 08 have been tasked to run observational tasks.", v2: "observer"));

      
        level1.Add(new LevelEvent(levelEventType.text, v1: "What a ironc call sign!", v2: "tanya"));
        level1.Add(new LevelEvent(levelEventType.text, v1: "Norden control, everything seems to be going as planned.", v2: "tanya"));
      
        level1.Add(new LevelEvent(levelEventType.text, v1: "z--zz--bbtt-zz-zz-z", v2: "observer"));
      
        level1.Add(new LevelEvent(levelEventType.text, v1: "What on earth? Interference?", v2: "tanya"));
      
      
        level1.Add(new LevelEvent(levelEventType.text, v1: "Our attack failed. Taking out observers and returning to base.", v2: "sueboss_undamaged"));
      
        level1.Add(new LevelEvent(levelEventType.text, v1: "An intercepted transmission?", v2: "tanya"));
        level1.Add(new LevelEvent(levelEventType.text, v1: "Observers? Are they referring to me?", v2: "tanya"));
      
        //spawn enemies and make tanya mad? call in HQ
      
        level1.Add(new LevelEvent(levelEventType.text, v1: "Task: Initiate Delaying action until reinforcements arrives", v2: "flag"));


        

        //level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level1.Add(new LevelEvent(levelEventType.enemy1, 1, loc:"up"));
        level1.Add(new LevelEvent(levelEventType.stop));


        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));
        level1.Add(new LevelEvent(levelEventType.enemy1, 1, loc: "left"));
        level1.Add(new LevelEvent(levelEventType.stop));
        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level1.Add(new LevelEvent(levelEventType.enemy3, 1, loc: "right"));
        level1.Add(new LevelEvent(levelEventType.stop));
        level1.Add(new LevelEvent(levelEventType.wait, 0, 2));

        level1.Add(new LevelEvent(levelEventType.enemy2, 1, loc: "up"));
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
                        enemymanager.GetComponent<EnemyManager1>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy2:
                        enemymanager.GetComponent<EnemyManager1>().Spawn(current);
                        ListIndex++;
                        break;
                    case levelEventType.enemy3:
                        enemymanager.GetComponent<EnemyManager1>().Spawn(current);
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
