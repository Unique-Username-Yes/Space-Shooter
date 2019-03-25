using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBrain : MonoBehaviour
{
    /*
     * Damage
     * Movement speed
     * Rotation speed
     * Rigidbody initialization
     * ? Have dmg calculation method
     * 
     */

    // ---------------------------------------------------------- Ranged
    public bool IsRanged { get => ship.weapon != null; }

    protected BaseShip ship;

    protected Transform firePoint;
    protected float timeToFire;
    // ----------------------------------------------------------

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No rigid body found in base brain");

        firePoint = transform.Find("FirePoint");
        if (!firePoint)
            Debug.LogError("No Firepoint found in base brain");

        ship = GetComponent<BaseShip>();
        if (!ship)
            Debug.LogError("No base ship found in base brain");
    }

    //protected void Shoot()
    //{
    //    //if (Time.time > timeToFire)
    //    //{
    //    //    timeToFire = Time.time + 1 / stats.FireRate;

    //    //    // TODO: Instantiate bullet here
    //    //}
    //}
}
