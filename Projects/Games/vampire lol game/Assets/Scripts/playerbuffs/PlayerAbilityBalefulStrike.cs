using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Champion: Zac
/// Description: When damaged, blobs fall out of player, picking one up heals players X damage
/// </summary>
public class PlayerAbilityBalefulStrike : AbilityBaseClass
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("added one instance of " + this.GetType().ToString());

    }

    // Update is called once per frame
    void Update()
    {

    }

}
