﻿using System.Collections;
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

            if (value > health)
            {
                healParticles.Play();
            }

            health = value;

            if (isReviving || Time.timeScale <= 0)
            {
                Debug.Log("Time stopped, returning");
                return;
            }

            if (health > startHealth)
            {
                health = startHealth;
            }

            if (health <= 0 && !isReviving && !isDead)
            {
                StartCoroutine(Death());
            }
        }
    }

    private float health = 100;

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
    
    [Tooltip("Animator for the player")]
    public Animator playerAnimator;
    #endregion
    
    [Tooltip("Reference to the Quiz manager")]
    public QuizManager quizManager;

    [Tooltip("Reference to the UI Manager")]
    public UIManager uiManager;

    [Tooltip("Reference to the GameMananger")]
    public GameManager gameManager;
    
    [Tooltip("Particles for showing magnetization")]
    public ParticleSystem magnetParticles;

    [Tooltip("Particles for when the player heals")]
    public ParticleSystem healParticles;

    [Tooltip("Can the player buy health")]
    public bool canBuy = true;

    [Tooltip("Buying health cooldown in seconds")]
    public float buyCooldown;

    private bool isDead = false;//if true play sound?
    
    /// <summary>
    /// Is the player reviving. True is so, false if not
    /// </summary>
    private bool isReviving;
    
    /// <summary>
    /// Should the magnet particles be played. True is yes, false if no
    /// </summary>
    private bool shouldPlayParticles = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0 && Health > 0)
        {
            Damage(healthDrainRate * Time.deltaTime);
        }

        shieldIcon.SetActive(shield > 0);
        
        if (isManget)
        {
            if (shouldPlayParticles)
            {
                magnetParticles.Play();
                shouldPlayParticles = false;
            }
        }
        else
        {
            shouldPlayParticles = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale >= 1)
        {
            uiManager.Pause();
        }
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.BuyHealth();
        }
    }
    
    public void Damage(float amount)
    {
        if (isReviving)
        {
            return;
        }
        
        if (shield > 0)
        {
            shield -= amount;
        } else
        {
            Health -= amount;
        }
    }
    
    private IEnumerator Death()
    {
        Debug.Log("Player died!");
        isDead = true;
        playerAnimator.SetTrigger("isDead");
        gameManager.speed = 0;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        quizManager.StartQuiz();
    }

    public void Revive()
    {
        Debug.Log("Player Reviving!");
        isReviving = true;
        isDead = false;
        ++timesRevived;
        health = startHealth;
        shield = 0;
        playerAnimator.SetTrigger("Revive");
        gameManager.speed = 5;
        Time.timeScale = 1;
        isReviving = false;
    }

    public IEnumerator SetBuyCooldown()
    {
        canBuy = false;
        uiManager.HideBuyButton();
        yield return new WaitForSeconds(buyCooldown);
        uiManager.ShowBuyButton();
        canBuy = true;
    }
}
