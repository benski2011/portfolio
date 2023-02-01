using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setscoresmenu : MonoBehaviour
{

    public bool HS = false;
    public bool prevscore = false;

    public enum MyEnum // *
    {
        level1,
        level2,
        level3,
        level4,
        level5,
        level6,
        level7,
        level8,
        level9,
        level10,
        level11,
        level12,

    }
    public MyEnum Tests;


    // Start is called before the first frame update
    void Start()
    {
        switch (Tests)
        {
            case MyEnum.level1:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level1_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level1_prevscore.ToString());

                }
                break;
            case MyEnum.level2:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level2_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level2_prevscore.ToString());

                }
                break;
            case MyEnum.level3:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level3_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level3_prevscore.ToString());

                }
                break;
            case MyEnum.level4:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level4_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level4_prevscore.ToString());

                }
                break;
            case MyEnum.level5:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level5_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level5_prevscore.ToString());

                }
                break;
            case MyEnum.level6:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level6_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level6_prevscore.ToString());

                }
                break;
            case MyEnum.level7:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level7_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level7_prevscore.ToString());

                }
                break;
            case MyEnum.level8:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level8_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level8_prevscore.ToString());

                }
                break;
            case MyEnum.level9:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level9_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level9_prevscore.ToString());

                }
                break;
            case MyEnum.level10:
                if (HS)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level10_highscore.ToString());
                }
                if(prevscore)
                {
                    this.GetComponent<TextMeshProUGUI>().SetText(mapEnabler.level10_prevscore.ToString());

                }
                break;
            case MyEnum.level11:
                break;
            case MyEnum.level12:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
