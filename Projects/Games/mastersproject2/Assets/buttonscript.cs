using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonscript : MonoBehaviour
{

    public enum buttontype { HoyreOpp, HoyreNed, VenstreOpp,VenstreNed, rullestol, posrot, negrot};

    float rightspeed;
    float leftspeed;
    float rotspeed;

    StaveController stave;

    //This is what you need to show in the inspector.
    public buttontype Tests;
    // Start is called before the first frame update
    void Start()
    {
        stave = GameObject.FindGameObjectWithTag("Player").GetComponent<StaveController>();

        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        rightspeed = stave.speedmodRight;
        leftspeed = stave.speedmodLeft;
        rotspeed = stave.rotationSpeed;

        if (Tests == buttontype.rullestol)
        {

            if (!stave.wheelchair)
            {
                this.GetComponent<Image>().color = Color.red;

            }

            if (stave.wheelchair)
            {
                this.GetComponent<Image>().color = Color.green;

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("textupdate");



        if (Tests == buttontype.HoyreNed)
        {
            stave.speedmodRight += -100;

            foreach (var item in gameObjects)
            {
                item.GetComponent<updatetext>().Updatetext();
            }

        }
        if (Tests == buttontype.HoyreOpp)
        {
            stave.speedmodRight += +100;
            foreach (var item in gameObjects)
            {
                item.GetComponent<updatetext>().Updatetext();
            }

        }
        if (Tests == buttontype.VenstreNed)
        {

            stave.speedmodLeft += -100;
            foreach (var item in gameObjects)
            {
                item.GetComponent<updatetext>().Updatetext();
            }
        }
        if (Tests == buttontype.VenstreOpp)
        {
            stave.speedmodLeft += 100;
            foreach (var item in gameObjects)
            {
                item.GetComponent<updatetext>().Updatetext();
            }
        }

        if (Tests == buttontype.rullestol)
        {
            stave.wheelchair = !stave.wheelchair;

            if (!stave.wheelchair)
            {
                this.GetComponent<Image>().color = Color.red;

            }

            if (stave.wheelchair)
            {
                this.GetComponent<Image>().color = Color.green;

            }
        }
        if (Tests == buttontype.posrot)
            {
                stave.rotationSpeed += 0.05f;
                foreach (var item in gameObjects)
                {
                    item.GetComponent<updatetext>().Updatetext();
                }
            }

        if (Tests == buttontype.negrot)
            {
                stave.rotationSpeed += -0.05f;
                foreach (var item in gameObjects)
                {
                    item.GetComponent<updatetext>().Updatetext();
                }
            }

        
    }
}
