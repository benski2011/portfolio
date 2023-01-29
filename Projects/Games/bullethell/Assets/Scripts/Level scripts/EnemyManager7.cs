using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// manager to keep track of enemy behavior and numbers
/// </summary>
public class EnemyManager7 : MonoBehaviour
{
    public GameObject audiomanager;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;

    public GameObject spawnSystem;
    SpawnSystemScript sp;
    GameObject gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        audiomanager = GameObject.FindWithTag("AudioManager");

        spawnSystem = GameObject.FindWithTag("SpawnSystem");
        sp = spawnSystem.GetComponent<SpawnSystemScript>();
    }



    internal void Spawn(LevelEvent type)
    {

        switch (type.type.ToString())
        {
            case "enemy1":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy1, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy1, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy1, type.number));
                        break;
                    default:
                        break;
                }
                break;
            case "enemy2":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy2, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy2, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy2, type.number));
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
                        StartCoroutine(sp.leftSpawn(enemy3, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy3, type.number));
                        break;
                    default:
                        break;
                }
                break;
            case "enemy4":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy4, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy4, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy4, type.number));
                        break;
                    default:
                        break;
                }
                break;
            case "enemy5":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy5, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy5, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy5, type.number));
                        break;
                    default:
                        break;
                }
                break;
            case "enemy6":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy6, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy6, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy6, type.number));
                        break;
                    default:
                        break;
                }
                break;
            case "enemy7":
                switch (type.location)
                {
                    case "up":
                        sp.upSpawn(enemy7, type.number);
                        break;

                    case "left":
                        StartCoroutine(sp.leftSpawn(enemy7, type.number));
                        break;

                    case "right":
                        StartCoroutine(sp.rightSpawn(enemy7, type.number));
                        break;
                    default:
                        break;
                }
                break;
        }


    }




}
