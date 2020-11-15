using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
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

    [Tooltip("Is the player magnetized. True is yes, false if no")]
    public bool isManget;

    [Tooltip("How large the magnet effect on the player is")]
    public float magnetRange;

    [Tooltip("How many times the player has revived")]
    public int timesRevived;
    
    [Tooltip("Maximum amount of times the player can revive")]
    public int maxRevives;
    #endregion
    
    [Tooltip("Reference to the Quiz manager")]
    public QuizManager quizManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            Damage(healthDrainRate * Time.deltaTime);
        }

        if (shield > 0)
        {
            shieldIcon.SetActive(true);
        }
        else
        {
            shieldIcon.SetActive(false);
        }
    }
    
    public void Damage(float amount)
    {
        if (shield > 0)
        {
            shield -= amount;
        } else
        {
            Health -= amount;
        }
    }
    
    private void Death()
    {
        Time.timeScale = 0;
        quizManager.StartQuiz();
    }

    public void Revive()
    {
        ++timesRevived;
        Health = startHealth;
        shield = 0;
        Time.timeScale = 1;
    }
}
