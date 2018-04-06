using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public GameObject laserPrefab;
    public float projectileSpeed = 3;
    public float maximumFireRate = 4;

    private float health = 100;
    private float currentFireDelay;
    private float lastFireTime;
    
    void Start()
    {
        currentFireDelay = Random.value * maximumFireRate;
        lastFireTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - lastFireTime) >= currentFireDelay)
        {
            FireLaser();
            lastFireTime = Time.time;
            currentFireDelay = Random.value * maximumFireRate;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.GetComponent<Projectile>();
        if (projectile)
        {
            health -= projectile.Damage;
            projectile.Hit();
            if (health <= 0) Destroy(gameObject);
        }
    }

    private void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }
}
