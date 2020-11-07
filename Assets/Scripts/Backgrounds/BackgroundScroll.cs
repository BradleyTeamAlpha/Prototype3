using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();//find game controller and get game manager out of it
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x -= (gameManager.speed/2) * Time.deltaTime;//should parallax the backgrounds
        transform.position = newPos;
        if(transform.position.x < -23.92)//replace -18 with magic number of background size with Charli. Trial and error baby!
        {
            Vector3 bgFix = new Vector3(23.92f, 0, 0);
            transform.position = bgFix;//could change
            Sprite temp = gameManager.Backgrounds();
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;//should set sprite to whatever game object gave-can do fancy logic in function later
        }
    }
}
