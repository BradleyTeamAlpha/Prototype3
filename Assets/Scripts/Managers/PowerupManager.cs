using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    [Tooltip("Reference to the Game Manager")]
    public GameManager gameManager;
    
    
    public IEnumerator SpeedPowerup(float speedMultiplier, float boostDuration)
    {
        float startSpeed = gameManager.speed;
        gameManager.speed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        gameManager.speed = startSpeed;
    }
}