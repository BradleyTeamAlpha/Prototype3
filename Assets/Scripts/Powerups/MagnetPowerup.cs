using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : PowerupBase
{
    private PowerupManager powerupManager;

    [Tooltip("How long the magnet effect lasts for")]
    public float duration;
    private void Start()
    {
        base.Start();
        powerupManager = GameObject.FindWithTag("GameController").GetComponent<PowerupManager>();
    }
    protected override void DoPowerup()
    {
        powerupManager.StartCoroutine(powerupManager.MagnetPowerup(duration));
    }
}
