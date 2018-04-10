using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float shipSpeed = 5f;
    public float limitPadding = 0.5f;
    public GameObject laserPrefab;
    public float projectileSpeed = 3;
    public float fireRate = 0.2f;
    public AudioClip damageSound;

    private float xMin;
    private float xMax;
    private float health = 100;
    private AudioSource laserSound;

    void Start()
    {
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        laserSound = GetComponent<AudioSource>();
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance)).x + limitPadding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance)).x - limitPadding;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (Input.GetKeyDown(KeyCode.Space)) InvokeRepeating("FireLaser", 0f, fireRate);
        if (Input.GetKeyUp(KeyCode.Space)) CancelInvoke("FireLaser");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.GetComponent<Projectile>();
        if (projectile)
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
            health -= projectile.Damage;
            projectile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Lose Screen");
            }
        }
    }

    private void UpdatePosition()
    {
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
            newPosition += Vector3.right * shipSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftArrow))
            newPosition += Vector3.left * shipSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        transform.position = newPosition;
    }

    private void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        laserSound.Play();
    }
}
