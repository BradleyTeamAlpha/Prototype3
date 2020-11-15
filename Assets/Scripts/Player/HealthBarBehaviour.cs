using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    private PlayerManager playerManager;

    private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindWithTag("GameController").GetComponent<PlayerManager>();
        healthSlider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        healthSlider.value = (playerManager.Health / 100);
    }
}
