using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        attacker.Attack(true, collider.gameObject);
    }
}
