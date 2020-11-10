using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public SmartGridManager smartGrid;
    
    public void BuyHealth()
    {
        if (gameManager.score >= smartGrid.cost)
        {
            gameManager.score -= smartGrid.cost;
            gameManager.Health += gameManager.healAmount;
        }
    }
}
