using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShooting : MonoBehaviour
{
    public BaseWeapon weapon;
    //[HideInInspector]
    public float fireRate;

    private float timeToFire = 0.0f;
    private Transform firePoint;

    Rigidbody2D playerShip;

    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (!firePoint)
            Debug.LogError("Cannot pewpew, no firepoint found");

        playerShip = GetComponent<Rigidbody2D>();
        if (!playerShip)
            Debug.LogError("No body found in PlayerShooting");
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            playerShip.AddForce((firePoint.up * -1) * weapon.recoil);
            weapon.Pewpew(firePoint);
        }
    }


}
