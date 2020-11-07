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

    [Tooltip("Player's score")]
    public int score;
    #region Player stuff
    /// <summary>
    /// Player's health
    /// </summary>
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health > startHealth)
            {
                health = startHealth;
            }
        } 
    }

    private float health;
        
    [Tooltip("Player's starting health, also their max")]
    public int startHealth;

    [Tooltip("How much health per second should be drained")]
    public float healthDrainRate;
    
    #endregion

    private void Start()
    {
        Health = startHealth;
    }

    private void Update()
    {
        Health -= healthDrainRate * Time.deltaTime;
    }
    
    /// <summary>
    /// Picks the next platform to spawn. Can do fancy logic here
    /// </summary>
    /// <returns>The next platform to spawn</returns>
    public PlatformData NextPlatform()
    {
        int rand = Random.Range(0, platforms.Count);

        return platforms[rand];
    }
}
