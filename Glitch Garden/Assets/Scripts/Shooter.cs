using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, projectileParent, gun;

    private void Fire()
    {
        Instantiate(projectile,
            (gun.transform.position),
            Quaternion.identity,
            projectileParent.transform);
    }
}
