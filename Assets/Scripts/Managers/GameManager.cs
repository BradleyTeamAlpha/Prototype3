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

    [Tooltip("How much the speed should be multiplied by by each score tick")]
    public float speedIncrease;
    
    [Tooltip("All possible platforms")]
    public List<PlatformData> platforms;
    
    [Tooltip("Backgrounds")]
    public List<Sprite> backgrounds;

    [Tooltip("The far back backgrounds")]
    public List<Sprite> reallyBackgrounds;
    
    #endregion

    [Tooltip("Reference to the UI Manager")]
    public UIManager uiManager;


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

    public Sprite NextReallyBackground()
    {
        int randomBG = Random.Range(0, backgrounds.Count);
        return reallyBackgrounds[randomBG];
    }

    private IEnumerator ScoreSystem()
    {
        while(true)
        {
            yield return new WaitForSeconds(scoreCooldown);
            score += scoreIncrease;
            speed *= speedIncrease;
            scoreCooldown -= scoreDecrease;
        }
    }

    public void EndGame()
    {
        uiManager.EndQuiz();
        uiManager.ShowEndgame();
    }
}
