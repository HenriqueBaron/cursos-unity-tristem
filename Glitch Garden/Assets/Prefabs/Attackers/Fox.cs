using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Attacker attacker;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("Jump");
        }
        else
        {
            attacker.Attack(true, collider.gameObject);
        }
    }
}
