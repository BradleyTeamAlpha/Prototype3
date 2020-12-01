using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    [Tooltip("Reference to the Game Manager")]
    public GameManager gameManager;

    [Tooltip("Reference to the Player Manager")]
    public PlayerManager playerManager;

    /// <summary>
    /// Is the speed powerup already active
    /// </summary>
    private bool isSpeed = false;
    
    public IEnumerator SpeedPowerup(float speedMultiplier, float boostDuration)
    {
        if (!isSpeed)
        {
            gameManager.speed *= speedMultiplier;
            isSpeed = true;
            yield return new WaitForSeconds(boostDuration);
            gameManager.speed /= speedMultiplier;
            isSpeed = false;
        }
    }

    public IEnumerator MagnetPowerup(float duration)
    {
        playerManager.isManget = true;
        yield return new WaitForSeconds(duration);
        playerManager.isManget = false;
    }

    public bool GetIsSpeed()
    {
        return isSpeed;
    }
}