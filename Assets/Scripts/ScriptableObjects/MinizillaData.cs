using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinizillaData")]
public class MinizillaData : ObstacleData
{
    [Tooltip("Projectile minizilla shoots")]
    public GameObject projectile;

    [Tooltip("How much time is between shots")]
    public float timeBetweenShots;
}