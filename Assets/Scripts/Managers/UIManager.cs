﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Tooltip("Reference to the GameManager")]
    public GameManager gameManager;

    [Tooltip("Reference to the Player Manager")]
    public PlayerManager playerManager;

    [Tooltip("Reference to the quiz manager")]
    public QuizManager quizManager;
    
    [Tooltip("Reference to the Smart Grid Manager")]
    public SmartGridManager smartGrid;

    [Tooltip("The text that displays the score")]
    public Text scoreText;

    [Tooltip("Image showing the price to recharge")]
    public Image smartMeterColor;

    [Tooltip("The colors to go between on reporting recharge cost")]
    public Gradient imageGradient;

    [Tooltip("Text that pops up when a fact is collected.")]
    public Text factText;

    [Tooltip("Parent object for the fact text")]
    public GameObject factObject;

    #region Quiz Stuff
    
    [Tooltip("Parent object for the quiz assets")]
    public GameObject quizObject;

    [Tooltip("Text for the current question")]
    public Text questionText;

    [Tooltip("Where the answers to the question get chosen")]
    public Dropdown answerChoices;

    [Tooltip("Button that selects an answer")]
    public Button answerSelect;

    [Tooltip("Button that advances from the confirmation screen")]
    public Button confirmationSelect;

    [Tooltip("The ending panel to be shown")]
    public GameObject endscreen;

    [Tooltip("Where the facts you have collected are displayed")]
    public Text factsText;
    #endregion
    public void BuyHealth()
    {
        if (gameManager.score >= smartGrid.cost)
        {
            gameManager.score -= smartGrid.cost;
            playerManager.Health += playerManager.healAmount;
        }
    }

    private void Update()
    {
        scoreText.text = gameManager.score.ToString();

        UpdateColor();
    }

    private void UpdateColor()
    {
        Color newColor = smartMeterColor.color;

        // Conversion to float to make sure decimals happen
        newColor = imageGradient.Evaluate((float) smartGrid.cost / smartGrid.costMax);

        smartMeterColor.color = newColor;
    }

    public void ShowFact(string fact)
    {
        factObject.SetActive(true);
        factText.text = fact;
    }

    public void HideFact()
    {
        Time.timeScale = 1;
        factObject.SetActive(false);
    }

    public void ShowQuiz()
    {
        string text = "";
        for (int i = 0; i < quizManager.aquiredFacts.Count; ++i)
        {
            text += quizManager.aquiredFacts[i] + "\n";
        }

        factsText.text = text;
        quizObject.SetActive(true);
    }

    public void EndQuiz()
    {
        quizObject.SetActive(false);
    }
    
    public void UpdateQuiz(QuestionInfo question)
    {
        answerChoices.options.Clear();
        List<string> options = new List<string>();
        //questionText.text = question.Question;
        string text = question.Question + "\n";
        char character = 'A';
        for (int i = 0; i < question.Answers.Length; ++i)
        {
            text += $"{character}: {question.Answers[i]}\n";
            options.Add(character.ToString());
            ++character;
        }
        answerChoices.AddOptions(options);
        questionText.text = text;
    }
    
    
    public void ChooseAnswer()
    {
        bool isCorrect = quizManager.CheckAnswer(answerChoices.value);

        answerSelect.gameObject.SetActive(false);
        confirmationSelect.gameObject.SetActive(true);

        string text = quizManager.currentQuestion.Answers[quizManager.currentQuestion.Correct];
        
        if (isCorrect)
        {
            text = "Correct, the answer is " + text;
        }
        else
        {
            text = "Incorrect, the answer is " + text;
        }
        
        questionText.text = text;
    }

    public void NextQuestion()
    {
        quizManager.QuestionSetup(quizManager.CheckAnswer(answerChoices.value));
        confirmationSelect.gameObject.SetActive(false);
        answerSelect.gameObject.SetActive(true);
    }

    public void ShowEndgame()
    {
        endscreen.SetActive(true);
    }
}
