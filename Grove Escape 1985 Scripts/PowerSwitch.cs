using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : InteractObject
{
    bool canTurnOn = true;
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        if (canTurnOn == true)
        {
            GameObject.Find("BigScreen").GetComponent<BigScreen>().CheckPower();
            canTurnOn = false;
        }
        
    }
}
