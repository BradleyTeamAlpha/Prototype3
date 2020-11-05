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
    
    public PlatformData NextPlatform()
    {
        int rand = Random.Range(0, platforms.Count);

        return platforms[rand];
    }
    

}
