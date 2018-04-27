using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startHealth = 100;

    private float healthLevel;

    // Use this for initialization
    void Start()
    {
        healthLevel = startHealth;
    }

    // Returns true if the component died.
    public bool Decrease(float damage)
    {
        healthLevel -= damage;
        if (healthLevel <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
}
