using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public ObstacleData data;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        data.DoBehaviour();
    }
    
}
