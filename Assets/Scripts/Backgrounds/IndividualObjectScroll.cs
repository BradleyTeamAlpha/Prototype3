using UnityEngine;

public class IndividualObjectScroll : MonoBehaviour
{
    [Tooltip("How much to slow the background down by")]
    public float scrollDivisor;

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
            Destroy(gameObject);
        }
    }
}
