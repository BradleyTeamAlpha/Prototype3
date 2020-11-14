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
    
    [Tooltip("How fast the platforms should go")]
    public float speed;
    
    [Tooltip("All possible platforms")]
    public List<PlatformData> platforms;
    
    [Tooltip("Backgrounds")]
    public List<Sprite> backgrounds;
    
    #endregion
    


    private void Start()
    {
        StartCoroutine(ScoreSystem());
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

    public Sprite NextBackground()
    {
        int randomBG = Random.Range(0, backgrounds.Count);
        return backgrounds[randomBG];
    }

    private IEnumerator ScoreSystem()
    {
        while(true)
        {
            yield return new WaitForSeconds(scoreCooldown);
            score += scoreIncrease;
            scoreCooldown -= scoreDecrease;
        }
    }

    public void EndGame()
    {
        Debug.Log("Game ended!");
    }
}
