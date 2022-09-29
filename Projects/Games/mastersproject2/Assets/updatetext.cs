using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatetext : MonoBehaviour
{
    public enum buttontype { HoyreSpeed, VenstreSpeed, rot};
    public buttontype Tests;

    float rspeed;
    float lspeed;
    float rot;

    StaveController stave;
    // Start is called before the first frame update
    void Start()
    {
        stave = GameObject.FindGameObjectWithTag("Player").GetComponent<StaveController>();
        rspeed = stave.speedmodRight;
        lspeed = stave.speedmodLeft;
        rot = stave.rotationSpeed;
        if (Tests == buttontype.HoyreSpeed)
        {
            this.GetComponent<Text>().text = "Hastighet : " + rspeed;

        }
        if (Tests == buttontype.VenstreSpeed)
        {
            this.GetComponent<Text>().text = "Hastighet : " + lspeed;

        }

        if (Tests == buttontype.rot)
        {
            this.GetComponent<Text>().text = "Rotasjon hastighet : " + rot;

        }
    }

    // Update is called once per frame
    public void Updatetext()
    {
        rspeed = stave.speedmodRight;
        lspeed = stave.speedmodLeft;
        rot = stave.rotationSpeed;


        if (Tests == buttontype.HoyreSpeed)
        {
            this.GetComponent<Text>().text = "Hastighet : " + rspeed;

        }
        if (Tests == buttontype.VenstreSpeed)
        {
            this.GetComponent<Text>().text = "Hastighet : " + lspeed;

        }
        if (Tests == buttontype.rot)
        {
            this.GetComponent<Text>().text = "Hastighet rotasjon : " + rot;

        }
    }
}
