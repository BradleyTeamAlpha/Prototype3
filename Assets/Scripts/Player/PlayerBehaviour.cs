using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Reference to the PlayerManager
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// Reference to the animator
    /// </summary>
    private Animator animator;
    
    /// <summary>
    /// Reference to the player's rigidbody2d
    /// </summary>
    private Rigidbody2D rb;

    [Tooltip("How hard the player should jump up")]
    public float jumpForce;

    private bool isJumping = false;
    
    [Tooltip("Particles to play when player is hurt")]
    public ParticleSystem hitParticles;

    [Tooltip("Shield hit particles")]
    public ParticleSystem shieldParticles;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 linecastEnd = transform.position;
        linecastEnd.y -= 1.2f;
        Debug.DrawLine(transform.position, linecastEnd);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, linecastEnd, (1 << 8));
        if (Input.GetButtonDown("Jump") && hit.transform.CompareTag("Platform") && Time.timeScale >= 1)
        {
            Debug.Log("Jumping!");
            isJumping = true;
            animator.SetTrigger("StartJump");
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (isJumping && hit != null && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            isJumping = false;
            animator.SetTrigger("EndJump");
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (playerManager.shield > 0)
            {
                shieldParticles.Play();
            }
            else
            {
                hitParticles.Play();
            }
            
            playerManager.Damage(other.GetComponent<ObstacleBehaviour>().GetData().damage);
        }
    }
}
