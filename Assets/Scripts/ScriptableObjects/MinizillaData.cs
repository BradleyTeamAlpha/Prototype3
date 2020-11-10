using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinizillaData")]
public class MinizillaData : ObstacleData
{
    [Tooltip("Fireball minizilla shoots")]
    public GameObject fireball;

    [Tooltip("How much time is between shots")]
    public float timeBetweenShots;
}