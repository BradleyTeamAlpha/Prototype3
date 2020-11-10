using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [Tooltip("The current platform")]
    public PlatformData data;

    /// <summary>
    /// Child object which holds the actual platform objects
        /// </summary>
        private GameObject platform;

    /// <summary>
    /// Reference to the Game Manager
    /// </summary>
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        platform = transform.GetChild(0).gameObject;
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;

        newPos.x -= gameManager.speed * Time.deltaTime;

        transform.position = newPos;
        
        if (transform.position.x < -data.length)
        {
            transform.position = gameManager.backgroundStart;
            data = gameManager.NextPlatform();
            DestroyImmediate(platform);
            platform = Instantiate(data.platform, new Vector3(gameManager.backgroundStart.x, -4.6f), Quaternion.identity, transform);
        }
    }
}
