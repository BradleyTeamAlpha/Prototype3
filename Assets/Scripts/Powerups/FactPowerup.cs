using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactPowerup : PowerupBase
{

    private QuizManager quizManager;

    private void Start()
    {
        quizManager = GameObject.FindWithTag("GameController").GetComponent<QuizManager>();
    }

    protected override void DoPowerup()
    {
        quizManager.AquireRandomFact();
    }
}
