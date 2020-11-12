using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    [Tooltip("Reference to the Game Manager")]
    public GameManager gameManager;
    
    
    public IEnumerator SpeedPowerup(float speedMultiplier, float boostDuration)
    {
        gameManager.speed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        gameManager.speed /= speedMultiplier;
    }

    public IEnumerator MagnetPowerup(float duration)
    {
        gameManager.isManget = true;
        yield return new WaitForSeconds(duration);
        gameManager.isManget = false;
    }
}