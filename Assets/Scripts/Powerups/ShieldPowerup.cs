using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerupBase
{

    private PlayerManager playerManager;

    [Tooltip("How much shield to give")]
    public float amount;
    
    private void Start()
    {
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
    }
    protected override void DoPowerup()
    {
        playerManager.shield = amount;
    }
}
