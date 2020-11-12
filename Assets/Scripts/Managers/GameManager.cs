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

            if (health <= 0)
            {
                Death();
            }
        }
    }

    private float health;

    public float shield;
    
    [Header("Player Variables")]
    [Tooltip("Player's starting health, also their max")]
    public int startHealth;

    [Tooltip("How much health per second should be drained")]
    public float healthDrainRate;

    [Tooltip("How much the Smart Grid heals the player per press")]
    public float healAmount;

    [Tooltip("Shield icon, used to display player is shielded.")]
    public GameObject shieldIcon;
    
    #endregion

    private void Start()
    {
        Health = startHealth;
        StartCoroutine(ScoreSystem());
    }

    private void Update()
    {
        Damage(healthDrainRate * Time.deltaTime);

        if (shield > 0)
        {
            shieldIcon.SetActive(true);
        }
        else
        {
            shieldIcon.SetActive(false);
        }
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

    private void Death()
    {
        Time.timeScale = 0;
    }

    public void Damage(float amount)
    {
        if (shield > 0)
        {
            shield -= amount;
        }

        if (shield < 0)
        {
            Health -= shield;
        }
        else
        {
            Health -= amount;
        }
    }
}
