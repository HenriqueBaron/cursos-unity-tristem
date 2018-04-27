using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Hit(collider.gameObject);
    }

    void Hit(GameObject target)
    {
        if (target.GetComponent<Attacker>())
        {
            Health health = target.GetComponent<Health>();
            if (health)
            {
                health.Decrease(damage);
            }
            else
            {
                Debug.LogWarning("Attacker has no Health component attached.");
            }
            Destroy(gameObject);
        }
    }
}
