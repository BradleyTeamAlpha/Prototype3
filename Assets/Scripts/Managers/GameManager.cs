using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Score
    
    [Header("Score Variables")]
    [Tooltip("Player's score")]
    public int score;

    [Tooltip("Score cooldown")]
    public float scoreCooldown;

    [Tooltip("Score timer decrease")]
    public float scoreDecrease;

    [Tooltip("How much the score should increase each score tick")]
    public int scoreIncrease;
    #endregion
    
    #region Scrolling
    
    [Header("Scrolling Variables")]
    [Tooltip("Where the backgrounds start moving from")]
    public Vector3 backgroundStart;

    [Tooltip("Where the backgrounds end (where they loop)")]
    public float backgroundEnd;
    
    [Tooltip("How fast the platforms should go")]
    public float speed;

    [Tooltip("How much the speed should be multiplied by by each score tick")]
    public float speedIncrease;
    
    [Tooltip("All possible platforms")]
    public List<PlatformData> platforms;
    
    [Tooltip("Backgrounds")]
    public List<Sprite> backgrounds;

    [Tooltip("The far back backgrounds")]
    public List<Sprite> reallyBackgrounds;

    [Tooltip("The fastest the game can go")]
    public float maxSpeed;

    [Tooltip("Reference to the PowerupManager")]
    public PowerupManager powerupManager;

    private int previousPlatform;
    #endregion

    [Tooltip("Reference to the UI Manager")]
    public UIManager uiManager;


    private void Start()
    {
        StartCoroutine(ScoreSystem());
    }

    /// <summary>
    /// Picks the next platform to spawn. Can do fancy logic here. Platform 5 cannot be next to Platform 7,
    /// 7 cannot be after 10
    /// </summary>
    /// <returns>The next platform to spawn</returns>
    public PlatformData NextPlatform()
    {
        int rand = Random.Range(0, platforms.Count);

        if ((previousPlatform == 4 && rand == 6) || (rand == 4 && previousPlatform == 6) 
            || previousPlatform == 9 && rand == 6)
        {
            rand -= 1;
        }

        previousPlatform = rand;
        return platforms[rand];
    }

    public Sprite NextBackground()
    {
        int randomBG = Random.Range(0, backgrounds.Count);
        return backgrounds[randomBG];
    }

    public Sprite NextReallyBackground()
    {
        int randomBG = Random.Range(0, backgrounds.Count);
        return reallyBackgrounds[randomBG];
    }

    private IEnumerator ScoreSystem()
    {
        Debug.Log("Starting score system!");
        while(true)
        {
            yield return new WaitForSeconds(scoreCooldown);
            score += scoreIncrease;
            if (speed < maxSpeed && !powerupManager.GetIsSpeed())
            {
                Debug.Log("Increasing speed!");
                speed *= speedIncrease;
            }
            
            Debug.Log("Increasing score!");
            scoreCooldown -= scoreDecrease;
        }
    }

    public void EndGame()
    {
        uiManager.EndQuiz();
        uiManager.ShowEndgame();
    }
}
