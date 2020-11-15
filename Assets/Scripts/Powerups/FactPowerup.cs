using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactPowerup : PowerupBase
{

    private QuizManager quizManager;

    private GameManager gameManager;

    [Tooltip("How many points the powerup is worth")]
    public int scoreIncrease;
    private void Start()
    {
        quizManager = GameObject.FindWithTag("GameController").GetComponent<QuizManager>();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    protected override void DoPowerup()
    {
        gameManager.score += scoreIncrease;
        quizManager.AquireRandomFact();
    }
}
