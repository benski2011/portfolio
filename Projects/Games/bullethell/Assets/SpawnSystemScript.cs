using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystemScript : MonoBehaviour
{
    public Transform TopLocation;
    public Transform LeftLocation;
    public Transform RightLocation;
    public Transform EndLocations;
    GameObject gameManager;


    public void Start()
    {
        TopLocation = transform.Find("TopSpawn");
        LeftLocation = transform.Find("LeftSpawn");
        RightLocation = transform.Find("RightSpawn");
        EndLocations = transform.Find("Locations");
        gameManager = GameObject.FindWithTag("GameManager");
    }

    public void rightSpawn(GameObject enemytest, int number)
    {
        gameManager.GetComponent<LevelBaseScript>().NumberOfEnemies+= number;
        if (number == 1)
        {
            GameObject e = Instantiate(enemytest, RightLocation.position, transform.rotation);
            e.AddComponent<EnemyMoveScript>();
            e.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(2).position;
            e.GetComponent<EnemyMoveScript>().speed = 10;

        }
        if (number == 2)
        {

        }
        if (number == 3)
        {

        }
    }

    public void leftSpawn(GameObject enemytest, int number)
    {
        gameManager.GetComponent<LevelBaseScript>().NumberOfEnemies += number;
        if (number == 1)
        {
            GameObject e = Instantiate(enemytest, LeftLocation.position, transform.rotation);
            e.AddComponent<EnemyMoveScript>();
            e.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(2).position;
            e.GetComponent<EnemyMoveScript>().speed = 10;

        }
        if (number == 2)
        {

        }
        if (number == 3)
        {

        }
    }

    public void upSpawn(GameObject enemytest, int number)
    {
        gameManager.GetComponent<LevelBaseScript>().NumberOfEnemies += number;
        if (number == 1)
        {
            GameObject e = Instantiate(enemytest, TopLocation.position, transform.rotation);
            e.AddComponent<EnemyMoveScript>();
            e.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(2).position;
            e.GetComponent<EnemyMoveScript>().speed = 10;

        }
        if (number == 2)
        {

        }
        if (number == 3)
        {

        }
    }
}
