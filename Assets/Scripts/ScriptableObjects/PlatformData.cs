using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlatformData")]
public class PlatformData : ScriptableObject
{
    /// <summary>
    /// The platform being held
    /// </summary>
    public GameObject platform;

    /// <summary>
    /// How long the platform is
    /// </summary>
    public float length = 10;
}
