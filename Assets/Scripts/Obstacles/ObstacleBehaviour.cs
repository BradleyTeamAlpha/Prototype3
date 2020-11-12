using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public ObstacleData data;

    protected GameManager gameManager;

    protected virtual void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    public ObstacleData GetData()
    {
        return data;
    }

}
