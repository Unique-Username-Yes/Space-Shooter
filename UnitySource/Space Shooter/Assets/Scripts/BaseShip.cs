using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShip : MonoBehaviour
{
    public int maxHealth = 50;
    public int health;

    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
