using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReallyBackgroundScroll : MonoBehaviour
{
    [Tooltip("How much to slow the background down by")]
    public float scrollDivisor;
    
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();//find game controller and get game manager out of it
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x -= (gameManager.speed/scrollDivisor) * Time.deltaTime;//should parallax the backgrounds
        transform.position = newPos;
        if(transform.position.x < -19)//replace -18 with magic number of background size with Charli. Trial and error baby!
        {
            Vector3 bgFix = new Vector3(19f, 0, 0);
            transform.position = bgFix;//could change
            Sprite temp = gameManager.NextReallyBackground();
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;//should set sprite to whatever game object gave-can do fancy logic in function later
        }
    }
}
