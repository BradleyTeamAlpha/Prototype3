using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : PowerupBase
{
    private GameManager gameManager;

    private PlayerManager playerManager;

    private GameObject player;
    
    [Tooltip("How much to increase the score by")]
    public int amount;
    
    private void Start()
    {
        base.Start();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    protected override void DoPowerup()
    {
        gameManager.score += amount;
    }
}
