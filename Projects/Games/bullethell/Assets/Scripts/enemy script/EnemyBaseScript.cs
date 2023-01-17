using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBaseScript : MonoBehaviour
{

    public int EnemyHp;
    public int EnemyShieldHp;
    public float EnemyMoveSpeed;
    public float EnemyDamage;
    public float EnemyFireRate;

    public GameObject player;
    public GameObject bullet;
    public Vector3 playerpos;

    public GameObject enemyRender;


    public Material newMaterialRef;

    public Renderer renderer;
    public Material currentMaterial;



    public void init(int enemyHp, int enemyShieldHp, float enemyMoveSpeed, float enemyDamage, float enemyFireRate)
    {
        EnemyHp = enemyHp;
        EnemyShieldHp = enemyShieldHp;
        EnemyMoveSpeed = enemyMoveSpeed;
        EnemyDamage = enemyDamage;
        EnemyFireRate = enemyFireRate;
        //player = GameObject.FindWithTag("Player").transform.Find("Player_midpoint").gameObject;
        playerpos = player.transform.position;
    }

    public void EnemyDeath()
    {
        Destroy(this);
    }

    private void CircleShot()
    {

        for (int i = 0; i <= 360; i += 10)
        {
            GameObject clone;
            clone = Instantiate(bullet);
            clone.GetComponent<playerbullet>().init(this.gameObject);
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
        clone.GetComponent<playerbullet>().init(this.gameObject);


        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = transform.position;

        Vector3 playerdir = (playerpos - transform.position).normalized;
        Vector3 arc = (playerpos - newVector).normalized;

        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);

        clone.GetComponent<bulletScript>().arcShot(newVector, this.transform.position,
            player.transform.position, 1500);


    }



    public void DecreaseHP(int dm)
    {
        EnemyHp -= dm;
        if (EnemyHp < 0)
        {
            EnemyDeath();
        }

        StartCoroutine(damage());

        IEnumerator damage()
        { 
            renderer.material = newMaterialRef;
            yield return new WaitForSeconds(0.15f);
            renderer.material = currentMaterial;

        }
    }

    private void Shoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);


        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = transform.position;

        Vector3 playerdir = (playerpos - transform.position).normalized;
        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);
        clone.GetComponent<Rigidbody>().AddForce(playerdir * 1500);
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

        clone.GetComponent<playerbullet>().init(this.gameObject);
        clone2.GetComponent<playerbullet>().init(this.gameObject);
        clone3.GetComponent<playerbullet>().init(this.gameObject);


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

    private void BurstShot()
    {
        //todo
    }




}
