using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// manager to keep track of enemy behavior and numbers
/// </summary>
public class EnemyManager10 : MonoBehaviour
{
    public GameObject audiomanager;
    public GameObject enemy;
    public GameObject enemy3;

    public GameObject enemyPlane;

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

    internal void Spawn(string type, int number)
    {
        switch (type)
        {
            case "enemy1":
                gameManager.GetComponent<Level10Spawns>().NumberOfEnemies++;
                Instantiate(enemytest, enemyStartPos, transform.rotation);
                Debug.Log("spawning: " + number + "of type " + type);
                break;
            case "enemy2": 
                gameManager.GetComponent<Level10Spawns>().NumberOfEnemies++;
                plane = Instantiate(enemyPlane, planespawnStart, enemyPlane.transform.rotation);
                Debug.Log("spawning: " + number + "of type " + type);
                isPlane = true;
                break;
            case "enemy3":
                gameManager.GetComponent<Level10Spawns>().NumberOfEnemies++;
                Instantiate(enemy3, enemyStartPos, enemy3.transform.rotation);
                Debug.Log("spawning: " + number + "of type " + type);
                break; 
            default:
                break;
        }

        
    }

    internal void SpawnPlane(string type, int number)
    {
        gameManager.GetComponent<Level10Spawns>().NumberOfEnemies++;
        plane = Instantiate(enemyPlane, planespawnStart, enemyPlane.transform.rotation);
        Debug.Log("spawning: " + number + "of type " + type);
        isPlane = true;
    }

    private void movePlane()
    {

        plane.transform.position = Vector3.MoveTowards(plane.transform.position, planespawnEnd, 0.05f);
    }

 
}
