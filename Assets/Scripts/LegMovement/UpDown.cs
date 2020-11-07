using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float yHighPos;//max point before coming back down
    public float yLowPos;//min point before going back up
    public float speed;
    public bool isUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thing = transform.position;
        if(isUp)
        {
            thing.y += speed * Time.deltaTime;
        }
        else
        {
            thing.y -= speed * Time.deltaTime;
        }
        
        if (thing.y >= yHighPos)
        {
            isUp = false;
            thing.y = 8.99f;
        }
        else if(thing.y <= yLowPos)
        {
            isUp = true;
            thing.y = 0.01f;
        }
        transform.position = thing;
    }
}
