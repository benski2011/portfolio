using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float firerate = 1f;
    float canfire = 1f;

    public GameObject bullet;
    public Transform muzzle;
    public GameObject shieldobj;
    public GameObject laserobj;
    public GameObject abilityvid;
    public AudioClip shieldClip; 
    public GameObject hpSprite;
    public GameObject shieldSprite;
    public GameObject abilitySprite;
    public GameObject deathscreen;


    private GameManager gm;

    public GameObject audio; 

    public float MoveSpeed = 1.0f;
    
    [SerializeField]
    int hp = 10;

    [SerializeField]
    int shield = 10;

    [SerializeField]
    float ability = 0f;

   

    private AudioManager AudioManager; 

    // Start is called before the first frame update
    void Start()
    {
        //attach audio and main manager
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        AudioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;

        //what is this
        abilitySprite.transform.localScale = new Vector2(0, abilitySprite.transform.localScale.y);

        increaseAbility();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if game is still running
        if (gm.GetComponent<GameManager>().GameEnd)
        {
            return;
        }

        //input manager - needs to be refactored
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * MoveSpeed * Time.deltaTime) ; ;
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * MoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * MoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            if (ability > 99)
            {
               // StartCoroutine(fireAbility());
               // decreaseAbility();
            }
            else
            {
                Debug.Log("cant fire ability");

            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Time.time > canfire)
            {
                Shoot();
                canfire = Time.time + firerate;
            }
            
               
        }
        

        if (Input.GetMouseButton(1))
        {
            if (shield != 0)
            {

                shieldobj.SetActive(true);
            }
            else
            {
                shieldobj.SetActive(false);

            }

        }
        else
        {
            shieldobj.SetActive(false);

        }

       // if (hp <=0)
       // {
       //     deathscreen.SetActive(true);
       //     Time.timeScale = 0;
       // }

    }

    private IEnumerator fireAbility()
    {

        abilityvid.SetActive(true);
        Time.timeScale = 0;

        yield return new WaitForSeconds(0.1f);

        abilityvid.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        laserobj.SetActive(true);
        AudioManager.PlayPlayerLaserAbilityAudio(2f);

        yield return new WaitForSeconds(2);

        laserobj.SetActive(false);


    }

    private void Shoot()
    {
        GameObject clone;
        clone = Instantiate(bullet);
        clone.GetComponent<playerbullet>().init(this.gameObject);

        AudioManager.PlayPlayerBulletAudio();
        clone.transform.position = muzzle.transform.position;
        // Give the cloned object an initial velocity along the current
        // object's Z axis
        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1500);
    }

    public void decreaseHP(int dm)
    {


        hp -= dm;

        


        if (hp < 0)
        {
            Debug.Log("u died :(");
            deathscreen.SetActive(true);
            gm.GetComponent<GameManager>().GameEnd = true;
        }
        hpSprite.GetComponent<Image>().fillAmount -= 0.1f;

        

    }
    public void increaseHP()
    {
        hp++;
        hpSprite.GetComponent<Image>().fillAmount += 10;

        //hpSprite.transform.localScale = new Vector2(hpSprite.transform.localScale.x + UIHP, hpSprite.transform.localScale.y);

    }
    public void decreaseShield(int dm)
    {
        if (shield > 0)
        {
            shield-= dm;
            AudioManager.PlayShieldAudio();
            shieldSprite.GetComponent<Image>().fillAmount -= 0.1f;

            //shieldSprite.transform.localScale = new Vector2(shieldSprite.transform.localScale.x - UIShield, shieldSprite.transform.localScale.y);
        }
    }
    public void increaseShield()
    {
        shield++;
        shieldSprite.GetComponent<Image>().fillAmount -= 0.1f;

        //shieldSprite.transform.localScale = new Vector2(shieldSprite.transform.localScale.x + UIShield, shieldSprite.transform.localScale.y);

    }

    public void increaseAbility()
    {
        if (ability<100)
        {
            ability += 1f;
            shieldSprite.GetComponent<Image>().fillAmount += 0.1f;

            //abilitySprite.transform.localScale = new Vector2(abilitySprite.transform.localScale.x + UIAbility, abilitySprite.transform.localScale.y);

        }


    }
    public void decreaseAbility()
    {

        ability = 0;
        shieldSprite.GetComponent<Image>().fillAmount = 0;

        //abilitySprite.transform.localScale = new Vector2(0, abilitySprite.transform.localScale.y);
    }

}

