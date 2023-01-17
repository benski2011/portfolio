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

    public IEnumerator rightSpawn(GameObject enemytest, int number)
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
            GameObject e1 = Instantiate(enemytest, RightLocation.position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, RightLocation.position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(2).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;

            yield return new WaitForSeconds(1);

            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(1).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;



        }
        if (number == 3)
        {
            GameObject e1 = Instantiate(enemytest, RightLocation.position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, RightLocation.position, transform.rotation);
            GameObject e3 = Instantiate(enemytest, RightLocation.position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(2).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;

            yield return new WaitForSeconds(1);

            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(1).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;

            yield return new WaitForSeconds(1);

            e3.AddComponent<EnemyMoveScript>();
            e3.GetComponent<EnemyMoveScript>().endpos = RightLocation.GetChild(0).position;
            e3.GetComponent<EnemyMoveScript>().speed = 10;

        }
    }

    public IEnumerator leftSpawn(GameObject enemytest, int number)
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
            GameObject e1 = Instantiate(enemytest, LeftLocation.position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, LeftLocation.position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(2).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;

            yield return new WaitForSeconds(1);


            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(0).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;

            
        }
        if (number == 3)
        {
            GameObject e1 = Instantiate(enemytest, LeftLocation.position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, LeftLocation.position, transform.rotation);
            GameObject e3 = Instantiate(enemytest, LeftLocation.position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(2).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;
            
            yield return new WaitForSeconds(1);

            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(1).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;

            yield return new WaitForSeconds(1);

            e3.AddComponent<EnemyMoveScript>();
            e3.GetComponent<EnemyMoveScript>().endpos = LeftLocation.GetChild(0).position;
            e3.GetComponent<EnemyMoveScript>().speed = 10;

        }
    }

    public void upSpawn(GameObject enemytest, int number)
    {
        gameManager.GetComponent<LevelBaseScript>().NumberOfEnemies += number;
        if (number == 1)
        {
            Transform spawnloc = TopLocation.GetChild(0);

            GameObject e = Instantiate(enemytest, spawnloc.GetChild(0).position, transform.rotation);
            e.AddComponent<EnemyMoveScript>();
            e.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(2).position;
            e.GetComponent<EnemyMoveScript>().speed = 10;

        }
        if (number == 2)
        {
            Transform spawnloc = TopLocation.GetChild(1);

            GameObject e1 = Instantiate(enemytest, spawnloc.GetChild(0).position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, spawnloc.GetChild(1).position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(1).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;


            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(3).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;

            
        }
        if (number == 3)
        {

            Transform spawnloc = TopLocation.GetChild(2);
            GameObject e1 = Instantiate(enemytest, spawnloc.GetChild(0).position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, spawnloc.GetChild(1).position, transform.rotation);
            GameObject e3 = Instantiate(enemytest, spawnloc.GetChild(2).position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(1).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;


            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(2).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;


            e3.AddComponent<EnemyMoveScript>();
            e3.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(3).position;
            e3.GetComponent<EnemyMoveScript>().speed = 10;
        }
        if (number == 4)
        {
            Transform spawnloc = TopLocation.GetChild(3);
            GameObject e1 = Instantiate(enemytest, spawnloc.GetChild(0).position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, spawnloc.GetChild(1).position, transform.rotation);
            GameObject e3 = Instantiate(enemytest, spawnloc.GetChild(2).position, transform.rotation);
            GameObject e4 = Instantiate(enemytest, spawnloc.GetChild(3).position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(0).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;


            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(1).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;


            e3.AddComponent<EnemyMoveScript>();
            e3.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(3).position;
            e3.GetComponent<EnemyMoveScript>().speed = 10;


            e4.AddComponent<EnemyMoveScript>();
            e4.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(4).position;
            e4.GetComponent<EnemyMoveScript>().speed = 10;

        }
        if (number == 5)
        {
            Transform spawnloc = TopLocation.GetChild(4);
            GameObject e1 = Instantiate(enemytest, spawnloc.GetChild(0).position, transform.rotation);
            GameObject e2 = Instantiate(enemytest, spawnloc.GetChild(1).position, transform.rotation);
            GameObject e3 = Instantiate(enemytest, spawnloc.GetChild(2).position, transform.rotation);
            GameObject e4 = Instantiate(enemytest, spawnloc.GetChild(3).position, transform.rotation);
            GameObject e5 = Instantiate(enemytest, spawnloc.GetChild(4).position, transform.rotation);

            e1.AddComponent<EnemyMoveScript>();
            e1.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(0).position;
            e1.GetComponent<EnemyMoveScript>().speed = 10;


            e2.AddComponent<EnemyMoveScript>();
            e2.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(1).position;
            e2.GetComponent<EnemyMoveScript>().speed = 10;


            e3.AddComponent<EnemyMoveScript>();
            e3.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(2).position;
            e3.GetComponent<EnemyMoveScript>().speed = 10;


            e4.AddComponent<EnemyMoveScript>();
            e4.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(3).position;
            e4.GetComponent<EnemyMoveScript>().speed = 10;


            e5.AddComponent<EnemyMoveScript>();
            e5.GetComponent<EnemyMoveScript>().endpos = EndLocations.GetChild(4).position;
            e5.GetComponent<EnemyMoveScript>().speed = 10;
        }
    }
}
