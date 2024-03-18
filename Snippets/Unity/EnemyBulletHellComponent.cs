using UnityEngine;

public class EnemyBulletHellComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;
    public float fireRate = 0.5f;
    public int bulletCount = 30;

    private float timeSinceLastFire = 0f;

    void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire >= fireRate)
        {
            ShootSpiral();
            ShootSineWave();
            ShootRandomVariation();
            ShootOscillatingSpiral();
            timeSinceLastFire = 0f;
        }
    }

    void ShootSpiral()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.right;
            FireBullet(direction);
        }
    }

    void ShootSineWave()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            float sineOffset = Mathf.Sin(angle * Mathf.Deg2Rad * 2); // Adjust frequency as needed
            Vector3 direction = Quaternion.Euler(0f, 0f, angle + sineOffset * 20) * Vector3.right; // Adjust amplitude as needed
            FireBullet(direction);
        }
    }

    void ShootRandomVariation()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            FireBullet(randomDirection);
        }
    }

    void ShootOscillatingSpiral()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            float oscillation = Mathf.Sin(angle * Mathf.Deg2Rad * 2); // Adjust frequency as needed
            Vector3 direction = Quaternion.Euler(0f, 0f, angle + oscillation * 45) * Vector3.right; // Adjust amplitude as needed
            FireBullet(direction);
        }
    }

    void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bullet.GetComponent<Bullet>();
        bullet.Move(direction * bulletSpeed);
    }
}
