using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObstacleDataBase")]
public class ObstacleData : ScriptableObject
{
    [Tooltip("How much damage the obstacle does")]
    public float damage;
}
