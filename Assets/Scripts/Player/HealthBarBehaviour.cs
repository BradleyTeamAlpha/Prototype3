using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    private GameManager gameManager;

    private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        healthSlider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        healthSlider.value = (gameManager.Health / 100);
    }
}
