using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerupBase
{

    private GameManager gameManager;

    [Tooltip("How much shield to give")]
    public float amount;
    
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    protected override void DoPowerup()
    {
        gameManager.shield = amount;
    }
}
