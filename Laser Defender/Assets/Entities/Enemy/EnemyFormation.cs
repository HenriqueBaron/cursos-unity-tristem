using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public GameObject laserPrefab;
    public float projectileSpeed = 3;
    public float maximumFireRate = 4;
    public int scoreValue = 150;
    public AudioClip damageSound;
    public AudioClip destroySound;

    private float health = 100;
    private float currentFireDelay;
    private float lastFireTime;
    private AudioSource laserSound;
    private ScoreKeeper scoreKeeper;

    void Start()
    {
        currentFireDelay = Random.value * maximumFireRate;
        lastFireTime = Time.time;
        laserSound = GetComponent<AudioSource>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
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
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
                scoreKeeper.Score(scoreValue);
                Destroy(gameObject);
            }
            else
            {
                AudioSource.PlayClipAtPoint(damageSound, transform.position);
            }
        }
    }

    private void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        laserSound.Play();
    }
}
