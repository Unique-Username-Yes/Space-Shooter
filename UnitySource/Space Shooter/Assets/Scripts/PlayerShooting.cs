using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public BaseWeapon weapon;

    float timeToFire = 0.0f;
    Transform firePoint;

    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (!firePoint)
            Debug.LogError("Cannot pewpew, no firepoint found");
    }

    private void Update()
    {
        if (weapon.fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Pewpew(firePoint);
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / weapon.fireRate;
                weapon.Pewpew(firePoint);
            }
        }
    }


}
