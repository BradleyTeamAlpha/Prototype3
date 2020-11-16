using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPowerup : PowerupBase
{
    private PlayerManager playerManager;

    public float healthGain;

    private void Start()
    {
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
    }
    
    protected override void DoPowerup()
    {
        playerManager.Health += healthGain;
    }
}
