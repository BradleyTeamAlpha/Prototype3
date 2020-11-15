using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.ThirdPerson;
public class MoveSelfBehavior : MonoBehaviour
{
    Rigidbody2D enemyBody;
    public int unitsToMove = 5;
    public float speed = 500;
    public bool isLeft;
    private float startPos;
    private float endPos;
    public bool moveLeft = true;

    public void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + unitsToMove;
        isLeft = transform.localScale.x > 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(moveLeft == true)
        {
            enemyBody.AddForce(Vector2.left * speed * Time.deltaTime);
            if(!isLeft)
            {
                Flip();
            }
        }
        if(enemyBody.position.x>=endPos)
        {
            moveLeft = false;
        }
        if(moveLeft == false)
        {
            enemyBody.AddForce(-Vector2.left * speed * Time.deltaTime);
            if(isLeft)
            {
                Flip();
            }
        }
        if(enemyBody.position.x<=startPos)
        {
            moveLeft = true;
        }
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isLeft = transform.localScale.x > 0;
    }
}
