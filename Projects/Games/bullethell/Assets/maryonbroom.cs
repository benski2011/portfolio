using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

/// <summary>
/// main enemy ai script
/// </summary>
public class maryonbroom : EnemyBaseScript
{
    public bool s_Shoot = true;
    public bool s_StraightShot = true;
    public bool s_ShootRay = true;
    public bool s_ShotGun = true;
    public bool s_ArcShot = true;
    public bool s_DelayedShoot = true;
    public bool s_BurstShot = true;

    public bool s_CircleShot = false;

    public float aimcriclesize = 2f;
    public float smgFireRate = 1f;
    public float normalFireRate = 0.5f;


    public float firerate = 0.5f;
    float canfire = 1f;

    public Vector3 pos1;
    public Vector3 pos2;

    GameObject ray;

    Vector3 goal;
    bool canmove = false;
    public float enemyHp;
    public GameManager gm;
    public bool RayExist = false;

    GameObject raypivot = null;
    public GameObject enemyPivot;
    public GameObject RayPrefab;

    public GameObject barrel;
    public GameObject playermidpoint;


    public AudioManager AudioPlayer;
    // Start is called before the first frame update

    public float stateDuration = 5f; // The duration of each state
    private float stateTimer = 0f; // A timer that counts down to the next state change
    private float fireTimer = 0f;

    private float currentFireRate = 0f;
    private enum State // An enumeration of the different states
    {
        Normal,
        Burst,

    }

    private State currentState = State.Burst;

    void Start()
    {

        currentFireRate = smgFireRate;

        playermidpoint = GameObject.FindWithTag("Player").transform.Find("Player_midpoint").gameObject;
        goal = pos1;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        barrel = this.transform.Find("BarrelEnd").gameObject;
        barrel.transform.position = new Vector3(barrel.transform.position.x, 0, barrel.transform.position.z);

        renderer = enemyRender.GetComponent<Renderer>();
        currentMaterial = renderer.material;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerpos = playermidpoint.transform.position;


        // Increment the timers
        stateTimer += Time.deltaTime;
        fireTimer += Time.deltaTime;

        // Check if it's time to switch states
        if (stateTimer >= stateDuration)
        {
            // Reset the timers
            stateTimer = 0f;
            fireTimer = 0f;

            // Switch to the next state
            switch (currentState)
            {
                case State.Normal:
                    currentState = State.Burst;
                    currentFireRate = smgFireRate;
                    break;
                case State.Burst:
                    currentState = State.Normal;
                    currentFireRate = normalFireRate;
                    break;
            }
        }

        // Check if it's time to fire
        if (fireTimer >= currentFireRate)
        {
            // Reset the fire timer
            fireTimer = 0f;

            // Fire a bullet or a shotgun burst depending on the current state
            switch (currentState)
            {
                case State.Normal:
                    Shoot();
                    break;
                case State.Burst:
                    Burst();
                    break;

            }
        }



        if (canmove)
        {
            Move();
        }

        if (ray)
        {
            ray.transform.position = this.transform.position;
            Vector3 direction = playermidpoint.transform.position - ray.transform.position;
            direction.y = 0;
            direction = direction.normalized;

            ray.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);


        }
    }

    private void CircleShot()
    {

        for (int i = 0; i <= 360; i += 10)
        {
            GameObject clone;
            clone = Instantiate(bullet);
            clone.transform.position = barrel.transform.position;

            Vector3 dir = (playermidpoint.transform.position - transform.position).normalized;
            Vector3 playerpos1 = Quaternion.Euler(0, i, 0) * dir;


            playerpos1.y = 0;

            clone.transform.LookAt(player.transform);

            clone.transform.Rotate(90, 0, 0);


            clone.GetComponent<Rigidbody>().AddForce(playerpos1 * 1500);

        }



    }

    private void ArcShot()
    {


        Vector3 playerDistanceDir = (player.transform.position - this.transform.position).normalized;
        playerDistanceDir.y = 0;
        Vector3 playerDistance = player.transform.position;

        playerDistanceDir.y = 0;
        Vector3 halfpoint = (((player.transform.position + this.transform.position) / 2));

        Debug.Log("dist: " + playerDistance + " halfway: " + halfpoint);

        Debug.DrawLine(this.transform.position, halfpoint, Color.red, 1f);

        Vector3 newVector = halfpoint - this.transform.position;
        Vector3 newVector2 = halfpoint - this.transform.position;

        newVector = Quaternion.AngleAxis(90, Vector3.up) * newVector;
        newVector2 = Quaternion.AngleAxis(-90, Vector3.up) * newVector2;

        newVector = newVector + halfpoint;
        newVector2 = newVector2 + halfpoint;

        Debug.DrawLine(halfpoint, newVector, Color.cyan, 1f);
        Debug.DrawLine(halfpoint, newVector2, Color.white, 1f);



        GameObject clone;
        clone = Instantiate(bullet);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = barrel.transform.position;

        Vector3 playerdir = (playermidpoint.transform.position - transform.position).normalized;
        Vector3 arc = (playermidpoint.transform.position - newVector).normalized;

        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);

        clone.GetComponent<bulletScript>().arcShot(newVector, this.transform.position,
            player.transform.position, 1500);


    }

    private void Move()
    {

        float step = 1 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, goal, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, goal) < 0.01f)
        {
            // Swap the position of the cylinder.
            if (goal == pos1)
            {
                goal = pos2;
            }
            else if (goal == pos2)
            {
                goal = pos1;
            }
        }
    }

    //public void DecreaseHP()
    //{
    //    if (enemyHp > 0)
    //    {
    //        enemyHp--;
    //    }
    //
    //}

    //private void Shoot()
    //{
    //    GameObject clone;
    //    clone = Instantiate(bullet);
    //    clone.GetComponent<playerbullet>().init(this.gameObject);
    //
    //    //AudioPlayer.PlayEnemyBulletAudio();
    //
    //    clone.transform.position = barrel.transform.position;
    //
    //    Vector3 playerdir = (playermidpoint.transform.position - barrel.transform.position).normalized;
    //    clone.transform.LookAt(playermidpoint.transform);
    //    clone.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
    //    clone.GetComponent<Rigidbody>().AddForce(playerdir * 1500);
    //}

    private void Shoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = barrel.transform.position;

        Vector3 playerdir = (playermidpoint.transform.position - barrel.transform.position).normalized;

        Vector3 aimTarget = playermidpoint.transform.position + (Random.insideUnitSphere * aimcriclesize); // set the aim target to be near the player but with some random offset
        aimTarget.y = 0; // set Y component to zero
        Debug.Log("Aim Target: " + aimTarget); // log the aim target vector
        Vector3 aimDirection = (aimTarget - barrel.transform.position).normalized;
        aimDirection.y = 0; // set Y component to zero
        Debug.DrawRay(barrel.transform.position, aimDirection * 500f, Color.green, 2f); // draw a debug ray to show the aim direction
        Debug.Log("Aim Direction: " + aimDirection); // log the aim direction vector
        clone.transform.rotation = Quaternion.LookRotation(aimDirection);
        clone.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
        clone.GetComponent<Rigidbody>().AddForce(new Vector3(aimDirection.x, 0, aimDirection.z) * 1500); // apply a 3D force to move the bullet in the X and Z directions
    }
    private void Burst()
    {

        StartCoroutine(burstshot());

        IEnumerator burstshot()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject clone;
                clone = Instantiate(bullet);
                clone.GetComponent<playerbullet>().init(this.gameObject);

                //AudioPlayer.PlayEnemyBulletAudio();

                clone.transform.position = barrel.transform.position;

                Vector3 playerdir = (playermidpoint.transform.position - transform.position).normalized;
                clone.transform.LookAt(playermidpoint.transform.position);
                clone.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
                clone.GetComponent<Rigidbody>().AddForce(playerdir * 1500);

                yield return new WaitForSeconds(0.1f);
            }

        }
    }
    private void StraightShot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);

        //AudioPlayer.PlayEnemyBulletAudio();
        clone.transform.position = barrel.transform.position;
        clone.transform.rotation *= Quaternion.Euler(new Vector3(0, -90, 0));

        clone.GetComponent<Rigidbody>().AddForce(-this.transform.forward * 1500);
    }

    private void DelayedShoot()
    {

        StartCoroutine(DelayShoot(5.0f, 5000));

        IEnumerator DelayShoot(float waitTime, int bulletSpeed)
        {
            Vector3 targetPos = player.transform.position;
            Debug.Log("starting delay of " + waitTime);
            yield return new WaitForSeconds(waitTime);

            GameObject clone;
            clone = Instantiate(bullet);

            clone.GetComponent<playerbullet>().init(this.gameObject);

            //AudioPlayer.PlayEnemyBulletAudio();

            clone.transform.position = barrel.transform.position;

            Vector3 playerdir = (targetPos - transform.position).normalized;
            clone.transform.LookAt(targetPos);
            clone.transform.Rotate(90, 0, 0);
            clone.GetComponent<Rigidbody>().AddForce(playerdir * bulletSpeed);


            Debug.Log("Finished Coroutine at timestamp : " + waitTime);
        }
    }




    private void ShotGun()
    {
        int[] array1 = new int[] { 0, 20, -20 };

        for (int i = 0; i < 3; i++)
        {
            GameObject clone1;

            clone1 = Instantiate(bullet);
            clone1.GetComponent<playerbullet>().init(this.gameObject);

            //AudioPlayer.PlayEnemyBulletAudio();

            clone1.transform.position = barrel.transform.position;

            Vector3 dir = (playermidpoint.transform.position - transform.position).normalized;

            Vector3 playerpos3 = Quaternion.Euler(0, array1[i], 0) * dir;

            playerpos3.y = 0;

            clone1.transform.LookAt(playermidpoint.transform);

            clone1.transform.Rotate(0, 90, 0);

            clone1.GetComponent<Rigidbody>().AddForce(playerpos3 * 1500);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "bullet")
        //{
        //    gm.GetComponent<LevelBaseScript>().NumberOfEnemies--;
        //    Destroy(this.gameObject);
        //}

    }
    private void OnDestroy()

    {
        gm.PlayerScore += 600;

        gm.GetComponent<LevelBaseScript>().NumberOfEnemies--;
        Destroy(this.gameObject);
    }


    private void ShootRay()
    {
        if (ray == null)
        {

            ray = Instantiate(RayPrefab);
            //ray.transform.parent = this.transform;
            ray.transform.position = barrel.transform.position;

        }


    }
}
