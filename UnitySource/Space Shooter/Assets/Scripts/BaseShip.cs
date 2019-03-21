using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseShip : MonoBehaviour
{
    protected int health;

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
