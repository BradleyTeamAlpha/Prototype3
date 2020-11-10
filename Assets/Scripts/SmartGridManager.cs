using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartGridManager : MonoBehaviour
{
    [Tooltip("Current price for recharging")]
    public int cost;

    [Tooltip("Maximum amount of time in seconds between changing the SmartGrid's cost")]
    public float costChangeTimeMax;

    [Tooltip("Minimum amount of time in seconds between changing the SmartGrid's cost")]
    public float costChangeTimeMin;

    [Tooltip("Maximum amount to change the cost by per tick. Positive only, computer decides if it is negative")]
    public int costChangeAmountCeil;

    [Tooltip("Minimum amount to change the cost by per tick. Positive only, computer decides if it is negative")]
    public int costChangeAmountFloor;

    [Tooltip("Maximum amount that the cost can be")]
    public int costMax;

    [Tooltip("Minimum amount that the cost can be")]
    public int costMin;
    
    private void Start()
    {
        StartCoroutine(ChangeCost());
    }

    private IEnumerator ChangeCost()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(costChangeTimeMin, costChangeTimeMax));
            
            // 40% chance to change the cost downward.
            bool isNeg = Random.Range(0, 10) >= 5;

            int toChange = Random.Range(costChangeAmountFloor, costChangeAmountCeil);

            if (isNeg)
            {
                toChange *= -1;
            }

            cost += toChange;

            if (cost > costMax)
            {
                cost = costMax;
            } 
            else if (cost < costMin)
            {
                cost = costMin;
            }
        }
    }
}
