﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : ObstacleBehaviour
{

    [Tooltip("How fast the fireball is")]
    public float speed;
    
    private void Update()
    {
        Vector2 newPos = transform.position;

        newPos.x -= (gameManager.speed + speed) * Time.deltaTime;

        transform.position = newPos;

        if (transform.position.x < -18)
        {
            Destroy(gameObject);
        }
    }
    
}
