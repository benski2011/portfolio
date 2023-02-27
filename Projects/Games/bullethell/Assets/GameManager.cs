using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameEnd = false; 
    private GameObject PlayerModel;

    public GameObject endscreen;

    public Vector3 PlayerRestrictionTopRight;
    public Vector3 PlayerRestrictionBotLeft;

    public GameObject textUi;

    public GameObject HSUi;
    public GameObject ScoreUi;


    public GameObject talkingImage;
    Level1Spawns level1Spawns;

    public Sprite tanyaimg;
    public Sprite vishaimg;
    public Sprite flagimg;
    public Sprite radioimg;
    public Sprite SueBoss_undamaged;
    public Sprite SueBoss_mad;
    public Sprite SueBoss_damaged;
    public Sprite Mary;
    public Sprite MaryMad;
    public Sprite observer;


    private int _playerScore = 0;

    public int PlayerScore
    {
        get { return _playerScore; }
        set
        {
            _playerScore = value;
            // Run your code here
            ScoreUi.GetComponent<TextMeshProUGUI>().text = _playerScore.ToString();

            Debug.Log("Player score updated to: " + _playerScore);
        }
    }
    public int highscore;


    public Sprite error;
    public string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {

        HSUi = GameObject.Find("scorenr").transform.GetChild(0).gameObject;
        ScoreUi = GameObject.Find("scorenr").transform.GetChild(1).gameObject;
        ScoreUi.GetComponent<TextMeshProUGUI>().text = 0.ToString();

        PlayerModel = GameObject.FindWithTag("Player");
        level1Spawns = this.GetComponent<Level1Spawns>();

        currentSceneName = SceneManager.GetActiveScene().name;
        setHighscore(currentSceneName);

    }

    private void setHighscore(string currentSceneName)
    {
        switch (currentSceneName)
        {
            case "Level 1":
                highscore = mapEnabler.level1_highscore;
                break;
            case "Level 2":
                highscore = mapEnabler.level2_highscore;
                break;
            case "Level 3":
                highscore = mapEnabler.level3_highscore;
                break;
            case "Level 4":
                highscore = mapEnabler.level4_highscore;
                break;
            case "Level 5":
                highscore = mapEnabler.level5_highscore;
                break;
            case "Level 6":
                highscore = mapEnabler.level6_highscore;
                break;
            case "Level 7":
                highscore = mapEnabler.level7_highscore;
                break;
            case "Level 8":
                highscore = mapEnabler.level8_highscore;
                break;
            case "Level 9":
                highscore = mapEnabler.level9_highscore;
                break;
            case "Level 10":
                highscore = mapEnabler.level10_highscore;
                break;
            default:
                // Handle invalid scene names
                break;

        }
        HSUi.GetComponent<TextMeshProUGUI>().text = highscore.ToString();
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
        SaveScore();
        GameEnd = true;
        ActivateMap.mapmenu = true;

        SceneManager.LoadScene("start menu");

        //endscreen.SetActive(true);

    }

    internal IEnumerator writeText(string text, string img)
    {
        string textToWrite = text;
        string image = img;


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
            case "radio":
                talkingImage.GetComponent<Image>().sprite = radioimg;
                break;
            case "sueboss_undamaged":
                talkingImage.GetComponent<Image>().sprite = SueBoss_undamaged;
                break;
            case "sueboss_mad":
                talkingImage.GetComponent<Image>().sprite = SueBoss_mad;
                break;
            case "sueboss_damaged":
                talkingImage.GetComponent<Image>().sprite = SueBoss_damaged;
                break;
            case "mary":
                talkingImage.GetComponent<Image>().sprite = Mary;
                break;
            case "marymad":
                talkingImage.GetComponent<Image>().sprite = MaryMad;
                break;
            case "observer":
                talkingImage.GetComponent<Image>().sprite = observer;
                break;

            default:
                break;
        }

        string inc = "";

        this.GetComponent<LevelBaseScript>().waitForText = true; 
        for (int i = 0; i < textToWrite.Length; i++)
        {
            inc += textToWrite[i];
            textUi.GetComponent<TMPro.TextMeshProUGUI>().text = inc;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        this.GetComponent<LevelBaseScript>().waitForText = false;
        this.GetComponent<LevelBaseScript>().time = 0.00f;
    }

    void SaveScore()
    {
        switch (currentSceneName)
        {
            case "Level 1":
                if (_playerScore > mapEnabler.level1_highscore)
                {
                    Debug.Log("saved game");
                    Debug.Log("score = "+ _playerScore);
                    Debug.Log("hs = " + mapEnabler.level1_highscore);

                    mapEnabler.level1_highscore = _playerScore;
                }
                mapEnabler.level1_prevscore = _playerScore;

                break;
            case "Level 2":
                if (_playerScore > mapEnabler.level2_highscore)
                {
                    mapEnabler.level2_highscore = _playerScore;
                }
                mapEnabler.level2_highscore = _playerScore;

                break;
            case "Level 3":
                if (_playerScore > mapEnabler.level3_highscore)
                {
                    mapEnabler.level3_highscore = _playerScore;
                }
                mapEnabler.level3_highscore = _playerScore;

                break;
            case "Level 4":
                if (_playerScore > mapEnabler.level4_highscore)
                {
                    mapEnabler.level4_highscore = _playerScore;
                }
                mapEnabler.level4_highscore = _playerScore;

                break;
            case "Level 5":
                if (_playerScore > mapEnabler.level5_highscore)
                {
                    mapEnabler.level5_highscore = _playerScore;
                }
                mapEnabler.level5_highscore = _playerScore;

                break;
            case "Level 6":
                if (_playerScore > mapEnabler.level6_highscore)
                {
                    mapEnabler.level6_highscore = _playerScore;
                }
                mapEnabler.level6_highscore = _playerScore;

                break;
            case "Level 7":
                if (_playerScore > mapEnabler.level7_highscore)
                {
                    mapEnabler.level7_highscore = _playerScore;
                }
                mapEnabler.level7_highscore = _playerScore;

                break;
            case "Level 8":
                if (_playerScore > mapEnabler.level8_highscore)
                {
                    mapEnabler.level8_highscore = _playerScore;
                }
                mapEnabler.level8_highscore = _playerScore;

                break;
            case "Level 9":
                if (_playerScore > mapEnabler.level9_highscore)
                {
                    mapEnabler.level9_highscore = _playerScore;
                }
                mapEnabler.level9_highscore = _playerScore;

                break;
            case "Level 10":
                if (_playerScore > mapEnabler.level10_highscore)
                {
                    mapEnabler.level10_highscore = _playerScore;
                }
                mapEnabler.level10_highscore = _playerScore;

                break;
            default:
                Debug.Log("error with score " + currentSceneName);
                break;
        }
    }
}
