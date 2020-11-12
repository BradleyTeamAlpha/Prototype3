﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Tooltip("Reference to the GameManager")]
    public GameManager gameManager;
    
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
    public void BuyHealth()
    {
        if (gameManager.score >= smartGrid.cost)
        {
            gameManager.score -= smartGrid.cost;
            gameManager.Health += gameManager.healAmount;
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
        factObject.SetActive(false);
    }
}
