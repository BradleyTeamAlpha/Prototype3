using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : PowerupBase
{
    private GameManager gameManager;

    private GameObject player;
    
    [Tooltip("How much to increase the score by")]
    public int amount;

    [Tooltip("How far away the magnet affects the coin")]
    public float magnetRange;

    [Tooltip("How quickly the coins move to the player")]
    public float floatSpeed;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }

    protected override void DoPowerup()
    {
        gameManager.score += amount;
    }

    private void Update()
    {
        if (gameManager.isManget)
        {
            if ((transform.position -= player.transform.position).magnitude <= magnetRange)
            {
                float step = floatSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
            }
        }
    }
}
