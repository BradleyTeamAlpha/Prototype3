
using System.Collections;
using UnityEngine;

public class SpeedPowerup : PowerupBase
{

    /// <summary>
    /// Reference to the GameManager
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// What speed the game started at
    /// </summary>
    private float startSpeed;

    [Tooltip("How long the boost lasts for")]
    public float boostDuration;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    
    
    protected override void DoPowerup()
    {
        startSpeed = gameManager.speed;
        gameManager.speed *= 1.3f;
        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(boostDuration);
        gameManager.speed = startSpeed;
    }
    
}