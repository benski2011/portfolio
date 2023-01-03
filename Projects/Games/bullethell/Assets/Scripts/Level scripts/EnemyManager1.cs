using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// manager to keep track of enemy behavior and numbers
/// </summary>
public class EnemyManager1 : MonoBehaviour
{
    public GameObject audiomanager;
    public GameObject enemy;
    public GameObject enemy3;

    public GameObject enemyPlane;
    public GameObject spawnSystem;
    SpawnSystemScript sp;
    GameObject gameManager;

    public GameObject enemytest;
    Vector3 enemyStartPos;
    Vector3 planespawnStart;
    Vector3 planespawnEnd;

    bool isPlane = false;
    GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        audiomanager = GameObject.FindWithTag("AudioManager");
        enemyStartPos = transform.Find("Enemies").transform.position;
        planespawnStart = transform.Find("planespawnStart").transform.position;
        planespawnEnd = transform.Find("planespawnEnd").transform.position;
        spawnSystem = GameObject.FindWithTag("SpawnSystem");
        sp = spawnSystem.GetComponent<SpawnSystemScript>();
        //StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(3);
        enemy.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (plane)
        {
            movePlane();
        }
        
    }

    internal void Spawn(LevelEvent type)
    {
        
      switch (type.type.ToString())
      {
          case "enemy1":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemytest, type.number);
                        break;

                    case "left":
                        sp.leftSpawn(enemytest, type.number);
                        break;

                    case "right":
                        sp.rightSpawn(enemytest, type.number);
                        break;
                    default:
                        break;
                }   
              break;
          case "enemy2":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemytest, type.number);
                        break;

                    case "left":
                        sp.leftSpawn(enemytest, type.number);
                        break;

                    case "right":
                        sp.rightSpawn(enemytest, type.number);
                        break;
                    default:
                        break;
                }
                break;
          case "enemy3":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy3, type.number);
                        break;

                    case "left":
                        sp.leftSpawn(enemy3, type.number);
                        break;

                    case "right":
                        sp.rightSpawn(enemy3, type.number);
                        break;
                    default:
                        break;
                }
                break;
      }

        
    }

    

    internal void SpawnPlane(string type, int number)
    {
        gameManager.GetComponent<Level1Spawns>().NumberOfEnemies++;
        plane = Instantiate(enemyPlane, planespawnStart, enemyPlane.transform.rotation);
        Debug.Log("spawning: " + number + "of type " + type);
        isPlane = true;
    }

    private void movePlane()
    {

        plane.transform.position = Vector3.MoveTowards(plane.transform.position, planespawnEnd, 0.05f);
    }

 
}
