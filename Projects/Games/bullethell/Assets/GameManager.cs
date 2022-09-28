using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameEnd = false; 
    private GameObject PlayerModel;

    public GameObject endscreen;

    public Vector3 PlayerRestrictionTopRight;
    public Vector3 PlayerRestrictionBotLeft;

    public GameObject textUi;
    public GameObject talkingImage;
    Level1Spawns level1Spawns;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;

    // Start is called before the first frame update
    void Start()
    {
        PlayerModel = GameObject.FindWithTag("Player");
        level1Spawns = this.GetComponent<Level1Spawns>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEnd)
        {
            return;
        }
        Vector3 playerTrans = PlayerModel.transform.localPosition;
        float playerTempPosX = PlayerModel.transform.localPosition.x;
        float playerTempPosZ = PlayerModel.transform.localPosition.z;

        if (playerTempPosX > PlayerRestrictionTopRight.x)
        {
            //right
            PlayerModel.transform.localPosition = new Vector3(PlayerRestrictionTopRight.x, playerTrans.y, playerTrans.z);

            Vector3 speed = PlayerModel.GetComponent<Rigidbody>().velocity;
            PlayerModel.GetComponent<Rigidbody>().velocity = new Vector3(0, speed.y, speed.z);
        }
        if (playerTempPosX < PlayerRestrictionBotLeft.x)
        {
            //left
            PlayerModel.transform.localPosition = new Vector3(PlayerRestrictionBotLeft.x, playerTrans.y, playerTrans.z);
            Vector3 speed = PlayerModel.GetComponent<Rigidbody>().velocity;
            PlayerModel.GetComponent<Rigidbody>().velocity = new Vector3(0, speed.y, speed.z);
        }

        if (playerTempPosZ > PlayerRestrictionTopRight.z)
        {
            //top
            PlayerModel.transform.localPosition = new Vector3(playerTrans.x, playerTrans.y, PlayerRestrictionTopRight.z);
            Vector3 speed = PlayerModel.GetComponent<Rigidbody>().velocity;
            PlayerModel.GetComponent<Rigidbody>().velocity = new Vector3(speed.x, speed.y, 0);

        }
        if (playerTempPosZ < PlayerRestrictionBotLeft.z)
        {
            //bot
            PlayerModel.transform.localPosition = new Vector3(playerTrans.x, playerTrans.y, PlayerRestrictionBotLeft.z);
            Vector3 speed = PlayerModel.GetComponent<Rigidbody>().velocity;
            PlayerModel.GetComponent<Rigidbody>().velocity = new Vector3(speed.x, speed.y, 0);

        }
    }

    internal void endGame()
    {
        GameEnd = true; 
        //endscreen.SetActive(true);

    }

    internal IEnumerator writeText(string text, string img)
    {
        string textToWrite = text;
        string image = img;

        Debug.Log(image);

        switch (image)
        {
            case "tanya": 
                talkingImage.GetComponent<Image>().sprite = tanyaimg;
                break;
            case "visha":
                talkingImage.GetComponent<Image>().sprite = vishaimg;
                break;
            case "flag":
                talkingImage.GetComponent<Image>().sprite = flagimg;
                break;

            default:
                break;
        }

        string inc = "";

        level1Spawns.waitForText = true; 
        for (int i = 0; i < textToWrite.Length; i++)
        {
            inc += textToWrite[i];
            textUi.GetComponent<TMPro.TextMeshProUGUI>().text = inc;
            yield return new WaitForSeconds(0.00f);
        }
        yield return new WaitForSeconds(0f);
        level1Spawns.waitForText = false;
        level1Spawns.time = 0;
    }
}
