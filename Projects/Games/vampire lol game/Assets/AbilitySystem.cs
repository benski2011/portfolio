using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> AbilityList = new List<string>();
    PlayerController playercontroller;

    void Start()
    {
        playercontroller = this.GetComponent<PlayerController>();

        DirectoryInfo dir = new DirectoryInfo(@"C:\Users\bensk\Documents\git\portfolio\Projects\Games\vampire lol game\Assets\Scripts\playerbuffs");
        FileInfo[] info = dir.GetFiles("*.cs");
        foreach (FileInfo f in info)
        {
            string ability = Path.GetFileName(f.ToString());
            ability = ability.Substring(0, ability.Length - 3);

            //Debug.Log(ability);
            //this.gameObject.AddComponent(System.Type.GetType(ability));
            AbilityList.Add(ability);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add player luck stat=

    public void NewAbility()
    {
        int rand1, rand2, rand3;
        rand1 = Random.Range(0, AbilityList.Count);

        do
        {
            rand2 = Random.Range(0, AbilityList.Count);

        } while (rand2 == rand1);

        do
        {
            rand3 = Random.Range(0, AbilityList.Count);

        } while (rand3 == rand2 || rand3 == rand1);

        Debug.Log(rand1+ "  "+ rand2+"  "+rand3);

        var ability1 = System.Type.GetType(AbilityList[rand1],true);
        string ability1string = AbilityList[rand1];
        var ability2 = System.Type.GetType(AbilityList[rand2], true);
        var ability3 = System.Type.GetType(AbilityList[rand3], true);

        if (playercontroller.gameObject.GetComponent(ability1))
        {
            Debug.Log("dupe");
            AbilityBaseClass temp = playercontroller.gameObject.GetComponent(ability1) as AbilityBaseClass;

            temp.IncreaseLevel();
        }
        else
        {
            playercontroller.gameObject.AddComponent(ability1);

        }
        if (playercontroller.gameObject.GetComponent(ability2))
        {
            Debug.Log("dupe");
            AbilityBaseClass temp = playercontroller.gameObject.GetComponent(ability2) as AbilityBaseClass;

            temp.IncreaseLevel();
        }
        else
        {
            playercontroller.gameObject.AddComponent(ability2);

        }
        if (playercontroller.gameObject.GetComponent(ability3))
        {
            Debug.Log("dupe");
            AbilityBaseClass temp = playercontroller.gameObject.GetComponent(ability3) as AbilityBaseClass;

            temp.IncreaseLevel();
        }
        else
        {
            playercontroller.gameObject.AddComponent(ability3);

        }


    }
}
