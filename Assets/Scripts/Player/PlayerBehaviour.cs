﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Reference to the GameManager
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// Reference to the player's rigidbody2d
    /// </summary>
    private Rigidbody2D rb;

    [Tooltip("How hard the player should jump up")]
    public float jumpForce;

    private bool isJumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 linecastEnd = transform.position;
        linecastEnd.y -= 2;
        Debug.DrawLine(transform.position, linecastEnd);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, linecastEnd, (1 << 8));
        if (Input.GetButtonDown("Jump") && hit.transform.CompareTag("Platform"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit player");
            gameManager.Health -= other.GetComponent<ObstacleBehaviour>().data.damage;
        }
    }
}
