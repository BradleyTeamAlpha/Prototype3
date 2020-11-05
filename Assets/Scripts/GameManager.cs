using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Where the backgrounds start moving from")]
    public Vector3 backgroundStart;
    
    [Tooltip("All possible platforms")]
    public List<PlatformData> platforms;

    [Tooltip("How fast the platforms should go")]
    public float speed;
    
    #region Player stuff
    /// <summary>
    /// Player's health
    /// </summary>
    public int health {
        get
        {
            return health;
        }
        set
        {
            if (health > startHealth)
            {
                health = startHealth;
            }
        } 
    }
        
    [Tooltip("Player's starting health, also their max")]
    public int startHealth;
    
    #endregion

    private void Start()
    {
        health = startHealth;
    }
    
    public PlatformData NextPlatform()
    {
        int rand = Random.Range(0, platforms.Count);

        return platforms[rand];
    }
    

}
