using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script for contolling the AI plane
/// </summary>
public class planeaicontroller : MonoBehaviour
{
    public GameObject player;

    GameObject rgun;
    GameObject lgun;
    GameObject frontgun;
    public GameObject bullet;

    public float bulletspeed = 1000;

    float canfire = 1f;
    public float firerate = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rgun = GameObject.Find("rgun");
        lgun = GameObject.Find("lgun");
        frontgun = GameObject.Find("frontgun");

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlane_frontgun = Vector3.Dot(frontgun.transform.up, player.transform.position - frontgun.transform.position);
        Vector3 pointOnPlane_frontgun = player.transform.position - (frontgun.transform.up * distanceToPlane_frontgun);
        frontgun.transform.LookAt(pointOnPlane_frontgun, frontgun.transform.up);

        float distanceToPlane_rgun = Vector3.Dot(rgun.transform.up, player.transform.position - rgun.transform.position);
        Vector3 pointOnPlane_rgun = player.transform.position - (rgun.transform.up * distanceToPlane_rgun);
        rgun.transform.LookAt(pointOnPlane_rgun, rgun.transform.up);

        float distanceToPlane_lgun = Vector3.Dot(lgun.transform.up, player.transform.position - lgun.transform.position);
        Vector3 pointOnPlane_lgun = player.transform.position - (frontgun.transform.up * distanceToPlane_lgun);
        lgun.transform.LookAt(pointOnPlane_lgun, lgun.transform.up);


        if (Time.time > canfire)
        {
            lgunShoot();
            rgunShoot();
            frontgunShoot();
            canfire = Time.time + firerate;
        }



    }

    private void frontgunShoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = frontgun.transform.GetChild(0).position;

        Vector3 playerpos = (player.transform.position - frontgun.transform.position).normalized;
        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);
        clone.GetComponent<Rigidbody>().AddForce(playerpos * bulletspeed);
    }

    private void rgunShoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = rgun.transform.GetChild(0).position;

        Vector3 playerpos = (player.transform.position - rgun.transform.position).normalized;
        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);
        clone.GetComponent<Rigidbody>().AddForce(playerpos * bulletspeed);
    }

    private void lgunShoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);

        //AudioPlayer.PlayEnemyBulletAudio();

        clone.transform.position = lgun.transform.GetChild(0).position;

        Vector3 playerpos = (player.transform.position - lgun.transform.position).normalized;
        clone.transform.LookAt(player.transform);
        clone.transform.Rotate(90, 0, 0);
        clone.GetComponent<Rigidbody>().AddForce(playerpos * bulletspeed);
    }
}
