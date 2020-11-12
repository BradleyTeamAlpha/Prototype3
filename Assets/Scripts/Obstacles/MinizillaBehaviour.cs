using System.Collections;
using UnityEngine;

public class MinizillaBehaviour : ObstacleBehaviour
{

    public MinizillaData data;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShootFireball());
    }


    private IEnumerator ShootFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(data.timeBetweenShots);
            Instantiate(data.projectile, transform.position, Quaternion.identity);
        }
    }
}