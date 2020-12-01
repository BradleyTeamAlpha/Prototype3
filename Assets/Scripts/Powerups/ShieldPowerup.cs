using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerupBase
{
  
    [Tooltip("How much shield to give")]
    public float amount;
    
    protected override void DoPowerup()
    {
        playerManager.shield = amount;
    }
}
