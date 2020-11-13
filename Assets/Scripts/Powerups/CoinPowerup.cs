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

    [Tooltip("How quickly the coins move to the player")]
    public float floatSpeed;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
        player = GameObject.FindWithTag("Player");
    }

    protected override void DoPowerup()
    {
        gameManager.score += amount;
    }

    private void Update()
    {
        if (playerManager.isManget)
        {
            Vector2 rangeEnd = player.transform.position;
            Debug.DrawLine(transform.position, rangeEnd);
            string[] masks = new[] {"Default", "Platform", "Player"};
            LayerMask mask = LayerMask.GetMask(masks);
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, mask);
            if (hit.transform.CompareTag("Player") && hit.distance < playerManager.magnetRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
                    (floatSpeed * Time.deltaTime));
            }
        }
    }
}
