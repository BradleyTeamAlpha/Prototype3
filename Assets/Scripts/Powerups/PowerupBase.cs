using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBase : MonoBehaviour
{
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
        
    }
}
