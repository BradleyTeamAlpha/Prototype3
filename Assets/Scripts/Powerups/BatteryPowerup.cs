using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPowerup : PowerupBase
{
    public float healthGain;
    
    
    protected override void DoPowerup()
    {
        playerManager.Health += healthGain;
    }
}
