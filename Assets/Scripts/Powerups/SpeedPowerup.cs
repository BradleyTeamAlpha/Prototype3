
using System.Collections;
using UnityEngine;

public class SpeedPowerup : PowerupBase
{

    /// <summary>
    /// Reference to the PowerupManager
    /// </summary>
    private PowerupManager manager;

    /// <summary>
    /// What speed the game started at
    /// </summary>
    private float startSpeed;

    [Tooltip("How long the boost lasts for")]
    public float boostDuration;

    [Tooltip("How much the powerup should boost speed")]
    public float boostMultiplier;
    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<PowerupManager>();
    }
    
    
    protected override void DoPowerup()
    {
        manager.StartCoroutine(manager.SpeedPowerup(boostMultiplier, boostDuration));
    }

}