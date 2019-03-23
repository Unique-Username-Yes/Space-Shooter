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
    public EnemyStats stats;

    // ---------------------------------------------------------- Ranged
    public BaseWeapon weapon;
    public bool IsRanged { get => weapon != null; }

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
    }

    protected virtual void Shoot()
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / stats.FireRate;

            weapon.Pewpew(firePoint);
        }
    }

    public abstract int CalcDmg(bool isBodyDamage);
}
