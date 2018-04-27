using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private GameObject target;
    private float currentSpeed = 0.5f;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        Health health = target.GetComponent<Health>();
        if (health)
        {
            if (health.Decrease(damage))
            {
                Attack(false);
            }
        }
        else
        {
            Debug.LogWarning("Current target has no Health component.");
        }
    }

    public void Attack(bool active, GameObject target = null)
    {
        if (active)
        {
            if (target.GetComponent<Defender>())
            {
                animator.SetBool("IsAttacking", active);
                this.target = target;
            }
        }
        else
        {
            animator.SetBool("IsAttacking", active);
            this.target = target;
        }
    }
}
