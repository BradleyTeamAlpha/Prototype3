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

    [Tooltip("Notification to show when facts are collected")]
    public GameObject factNotification;

    [Tooltip("How long to show the notification for")]
    public float notificationTime;

    [Tooltip("Sound to play when buying health")]
    public AudioSource buySound;

    [Tooltip("Sound to play when answering a question wrong")]
    public AudioSource wrongAnsSound;

    [Tooltip("Sound to play when answering a question correctly")]
    public AudioSource rightAnsSound;

    [Tooltip("The button that allows health to be bought")]
    public GameObject buyHealthButton;

    [Tooltip("Text for the pause menu facts")]
    public Text pauseFactText;
    
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

    [Tooltip("Reference to the pause menu")]
    public GameObject pauseMenu;
    
    [Tooltip("Reference to the text to show players score")]
    public Text endScoreText;
    #endregion
    public void BuyHealth()
    {
        if (gameManager.score >= smartGrid.cost && Time.timeScale >= 1 && playerManager.canBuy)
        {
            gameManager.score -= smartGrid.cost;
            playerManager.Health += playerManager.healAmount;
            StartCoroutine(playerManager.SetBuyCooldown());
            buySound.Play();
        }
    }

    private void Update()
    {
        scoreText.text = gameManager.score.ToString();

        UpdateColor();
    }

    private void UpdateColor()
    {
        if (!playerManager.canBuy)
        {
            return;
        }
        Color newColor = smartMeterColor.color;

        // Conversion to float to make sure decimals happen
        newColor = imageGradient.Evaluate((float) smartGrid.cost / smartGrid.costMax);

        smartMeterColor.color = newColor;
    }

    public void ShowFact(string fact)
    {
        factObject.SetActive(true);
        factText.text = fact;
        UpdateCollectedFactsText(pauseFactText);
    }

    public void HideFact()
    {
        Time.timeScale = 1;
        factObject.SetActive(false);
    }

    public void ShowQuiz()
    {
        UpdateCollectedFactsText(factsText);
        quizObject.SetActive(true);
    }

    private void UpdateCollectedFactsText(Text textToUpdate)
    {
        string text = "";
        for (int i = 0; i < quizManager.aquiredFacts.Length; ++i)
        {
            text += "- " + quizManager.aquiredFacts[i] + "\n\n";
        }

        textToUpdate.text = text;
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

    public IEnumerator ShowNotification()
    {
        UpdateCollectedFactsText(pauseFactText);
        factNotification.SetActive(true);
        yield return  new WaitForSeconds(notificationTime);
        factNotification.SetActive(false);
    }
    
    public void ChooseAnswer()//put wrong/right answer sound effect here
    {
        bool isCorrect = quizManager.CheckAnswer(answerChoices.value);

        answerSelect.gameObject.SetActive(false);
        confirmationSelect.gameObject.SetActive(true);
        answerChoices.gameObject.SetActive(false);
        
        QuestionInfo question = quizManager.currentQuestion;
        string text = question.Question;
        
        if (isCorrect)
        {
            rightAnsSound.Play();
            text += "\n\nCorrect, the answer is ";
        }
        else
        {
            wrongAnsSound.Play();
            text += "\n\nIncorrect, the answer is ";
        }

        text += question.Answers[quizManager.currentQuestion.Correct];
        
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
        endScoreText.text = $"You scored {gameManager.score} points!";
        endscreen.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        buyHealthButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        buyHealthButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void HideBuyButton()
    {
        smartMeterColor.color = Color.black;
        buyHealthButton.SetActive(false);
    }

    public void ShowBuyButton()
    {
        buyHealthButton.SetActive(true);
    }
}
