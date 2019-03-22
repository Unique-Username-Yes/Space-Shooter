using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseShip : MonoBehaviour
{
    protected int health;
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("Rigid body not found in BaseShip");
    }

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
