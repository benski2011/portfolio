using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInitTest : MonoBehaviour
{

    public GameObject ai;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemytest = Instantiate(ai);
        EnemyBaseScript test = enemytest.GetComponent<EnemyBaseScript>();
        test.init(10, 10, 10f, 10f, 10f);
    }

    // Update is called once per frame
        void Update()
    {
        
    }
}
