using System;
using UnityEngine;

public class FactPowerup : PowerupBase
{

    private QuizManager quizManager;

    private GameManager gameManager;

    [Tooltip("How many points the powerup is worth")]
    public int scoreIncrease;
    private void Start()
    {
        base.Start();
        quizManager = GameObject.FindWithTag("GameController").GetComponent<QuizManager>();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    protected override void DoPowerup()
    {
        gameManager.score += scoreIncrease;
        try
        {
            quizManager.AquireRandomFact();
        }
        catch (Exception e)
        {
            Debug.Log("Ran out of facts!");
        }

        base.DoPowerup();
    }
}
