using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcehighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mapEnabler.level1_highscore =900;
        mapEnabler.level2_highscore =1100;
        mapEnabler.level3_highscore = 1700;
        mapEnabler.level4_highscore = 1500;
        mapEnabler.level5_highscore = 1600;
        mapEnabler.level6_highscore = 1300;
        mapEnabler.level7_highscore = 2000;
        mapEnabler.level8_highscore = 1200;
        mapEnabler.level9_highscore = 1700;
        mapEnabler.level10_highscore= 1600;

        mapEnabler.level1_prevscore = 900;
        mapEnabler.level2_prevscore = 800;
        mapEnabler.level3_prevscore = 700;
        mapEnabler.level4_prevscore = 1100;
        mapEnabler.level5_prevscore = 900;
        mapEnabler.level6_prevscore = 600;
        mapEnabler.level7_prevscore = 900;
        mapEnabler.level8_prevscore = 2000;
        mapEnabler.level9_prevscore = 1500;
        mapEnabler.level10_prevscore = 900;



        // Handle invalid scene names

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
