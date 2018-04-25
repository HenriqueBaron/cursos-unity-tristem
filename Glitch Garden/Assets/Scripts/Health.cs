using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float level = 100;

    // Use this for initialization
    void Start()
    {

    }

    // Returns true if the component died.
    public bool Decrease(float damage)
    {
        level -= damage;
        if (level <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
}
