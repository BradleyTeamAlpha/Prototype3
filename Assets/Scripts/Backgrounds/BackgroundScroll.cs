﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Tooltip("How much to slow the background down by")]
    public float scrollDivisor;

    public GameObject otherBackground;
    
    private GameManager gameManager;

    private Camera mainCamera;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();//find game controller and get game manager out of it
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x -= (gameManager.speed/scrollDivisor) * Time.deltaTime;//should parallax the backgrounds
        transform.position = newPos;
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        //if(transform.position.x <= gameManager.backgroundEnd)//replace -18 with magic number of background size with Charli. Trial and error baby!
        if (screenPoint.x <= -0.55f)
        {
            //Vector3 bgFix = new Vector3(19f, 0, 0);
            //transform.position = gameManager.backgroundStart;
            Vector2 viewportPoint = Vector2.right;
            viewportPoint.x += 0.62f;
            viewportPoint.y = 0.5f;
            Vector3 loopPos = mainCamera.ViewportToWorldPoint(viewportPoint);
            transform.position = loopPos;
            Sprite temp = gameManager.NextBackground();
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;//should set sprite to whatever game object gave-can do fancy logic in function later
        }
    }
}
