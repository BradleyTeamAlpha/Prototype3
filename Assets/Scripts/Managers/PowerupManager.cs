using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    [Tooltip("Reference to the Game Manager")]
    public GameManager gameManager;

    [Tooltip("Reference to the Player Manager")]
    public PlayerManager playerManager;
    
    public IEnumerator SpeedPowerup(float speedMultiplier, float boostDuration)
    {
        gameManager.speed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        gameManager.speed /= speedMultiplier;
    }

    public IEnumerator MagnetPowerup(float duration)
    {
        playerManager.isManget = true;
        yield return new WaitForSeconds(duration);
        playerManager.isManget = false;
    }
}