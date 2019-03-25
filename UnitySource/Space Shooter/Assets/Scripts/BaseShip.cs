using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class BaseShip : MonoBehaviour
{
    public GameObject effects;
    public Stats stats;
    public BaseWeapon weapon;

    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            currentHealth = maxHealth;
        }
    }

    protected int maxHealth;
    public int currentHealth;

    protected float timeToFire;
    protected Rigidbody2D rb;
    protected Transform firePoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No rigid body found in base ship");

        firePoint = transform.Find("FirePoint");
        if (!firePoint)
            Debug.LogError("No firepoint found in base ship");

        MaxHealth = (int)stats.MaxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameObject effect_obj = Instantiate(effects, transform.position, Quaternion.identity);
        effect_obj.GetComponent<ParticleSystem>().Play();
        Destroy(effect_obj, 5.0f);
        Destroy(gameObject);
    }

    public virtual void Shoot()
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / stats.FireRate + weapon.weaponFireRateBonus;
            // TODO: Instantiate bullet here
            GameObject bullet = Instantiate(weapon.bulletP, firePoint.position, firePoint.rotation);
            bullet.transform.parent = transform;

            rb.AddForce((firePoint.up * -1) * weapon.recoil);
        }
    }
    public virtual int CalcDmg(bool IsRangedAttack)
    {
        if (IsRangedAttack)
        {
            return (int)(stats.BulletDmg+weapon.bulletSpeedBonus);
        }
        else
        {
            return (int)stats.BodyDmg;
        }
    }
}
