using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// main enemy ai script
/// </summary>
public class enemyScript : EnemyBaseScript
{
    public float firerate = 0.5f;
    float canfire = 1f;

    public Vector3 pos1;
    public Vector3 pos2;

    GameObject ray;

    Vector3 playerpos; 
    Vector3 goal;
    bool canmove = false; 
    public float enemyHp;
    public GameManager gm;
    public bool RayExist = false;

    GameObject raypivot = null;
    public GameObject enemyPivot;
    public GameObject RayPrefab;


    public AudioManager AudioPlayer; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.Find("Player_midpoint").gameObject;
        goal = pos1;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position;

        if (Time.time > canfire)
        {
            //Shoot();
            StraightShot();
            //ShootRay();
            //ShotGun();
            //ArcShot();
            //DelayedShoot();
            //CircleShot();
            canfire = Time.time + firerate;
        }
        if (canmove)
        {
            Move();
        }
        
        if(ray)
        {
           ray.transform.position = this.transform.position;
           Vector3 direction = playerpos - ray.transform.position;
           direction.y = 0;
           direction = direction.normalized;
           
           ray.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);


        }
    }

    private void CircleShot()
    {

        for (int i = 0; i <= 360; i+=10)
        {
            GameObject clone;
            clone = Instantiate(bullet);
            clone.transform.position = transform.position;

            Vector3 dir = (playerpos - transform.position).normalized;
            Vector3 playerpos1 = Quaternion.Euler(0, i, 0) * dir;


            playerpos1.y = 0;

            clone.transform.LookAt(player.transform);

            clone.transform.Rotate(90, 0, 0);


            clone.GetComponent<Rigidbody>().AddForce(playerpos1 * 1500);

        }



    }

    private void ArcShot()
    {
        

        Vector3 playerDistanceDir = (player.transform.position-this.transform.position ).normalized;
        playerDistanceDir.y = 0;
        Vector3 playerDistance = player.transform.position;

        playerDistanceDir.y = 0;
        Vector3 halfpoint = (((player.transform.position + this.transform.position) / 2));

        Debug.Log("dist: " + playerDistance + " halfway: "+ halfpoint );
        
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

        clone.transform.position = transform.position;

        Vector3 playerdir = (playerpos - transform.position).normalized;
        Vector3 arc = (playerpos - newVector).normalized;

        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);

        clone.GetComponent<bulletScript>().arcShot(newVector,this.transform.position,
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

    private void Shoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = transform.position;

        Vector3 playerdir = (playerpos - transform.position).normalized;
        clone.transform.LookAt(player.transform);
        clone.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
        clone.GetComponent<Rigidbody>().AddForce(playerdir * 1500);
    }
    private void StraightShot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);

        //AudioPlayer.PlayEnemyBulletAudio();
        clone.transform.position = transform.position;
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

            clone.transform.position = transform.position;

            Vector3 playerdir = (targetPos - transform.position).normalized;
            clone.transform.LookAt(targetPos);
            clone.transform.Rotate(90, 0, 0);
            clone.GetComponent<Rigidbody>().AddForce(playerdir * bulletSpeed);


            Debug.Log("Finished Coroutine at timestamp : " + waitTime);
        }
    }




    private void ShotGun()
    {
        GameObject clone;
        GameObject clone2;
        GameObject clone3;

        clone = Instantiate(bullet);
        clone2 = Instantiate(bullet);
        clone3 = Instantiate(bullet);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = transform.position;
        clone2.transform.position = transform.position;
        clone3.transform.position = transform.position;

        Vector3 dir = (playerpos - transform.position).normalized;
        Vector3 playerpos1 = Quaternion.Euler(0, 0, 0) * dir;
        Vector3 playerpos2 = Quaternion.Euler(0, 20, 0) * dir;
        Vector3 playerpos3 = Quaternion.Euler(0, -20, 0) * dir;

        playerpos1.y = 0;
        playerpos2.y = 0;
        playerpos3.y = 0;
        clone.transform.LookAt(player.transform);
        clone2.transform.LookAt(player.transform);
        clone3.transform.LookAt(player.transform);



        clone.transform.Rotate(90, 0, 0);
        clone2.transform.Rotate(90, 0, 0);
        clone3.transform.Rotate(90, 0, 0);



        clone.GetComponent<Rigidbody>().AddForce(playerpos * 1500);
        clone2.GetComponent<Rigidbody>().AddForce(playerpos2 * 1500);

        clone3.GetComponent<Rigidbody>().AddForce(playerpos3 * 1500);
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
        gm.GetComponent<LevelBaseScript>().NumberOfEnemies--;
        Destroy(this.gameObject);
    }


    private void ShootRay()
    {
        if (ray == null)
        {

            ray = Instantiate(RayPrefab);
            //ray.transform.parent = this.transform;
            ray.transform.position = this.transform.position;

        }


    }
}
