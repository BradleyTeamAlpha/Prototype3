using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBase : MonoBehaviour
{

    protected PlayerManager playerManager;

    protected GameObject player;
    
    [Tooltip("How quickly the powerups move to the player")]
    public float floatSpeed;
    protected void Start()
    {
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
        player = GameObject.FindWithTag("Player");
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoPowerup();
            Destroy(gameObject);
        }
    }

    protected virtual void DoPowerup()
    {
        Destroy(gameObject);
    }
    
    protected void Update()
    {
        if (playerManager.isManget)
        {
            Vector2 rangeEnd = player.transform.position;
            Debug.DrawLine(transform.position, rangeEnd);
            string[] masks = {"Default", "Platform", "Player"};
            LayerMask mask = LayerMask.GetMask(masks);
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, mask);
            if (hit.transform.CompareTag("Player") && hit.distance < playerManager.magnetRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
                    (floatSpeed * Time.deltaTime));
            }
        }
    }
}
