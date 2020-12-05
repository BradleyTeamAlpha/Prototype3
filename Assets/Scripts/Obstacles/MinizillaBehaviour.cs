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
            Vector2 shootPos = transform.position;
            shootPos.y += 0.9f;
            Instantiate(data.projectile, shootPos, Quaternion.Euler(0, 0, 270));
        }
    }
}