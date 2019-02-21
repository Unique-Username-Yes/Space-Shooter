using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAmmo : MonoBehaviour
{
    public int Damage { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }
    public Vector2 StartPos { get; set; }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(Damage);
            Debug.Log("Took dmg: "+ Damage);
        }
        Destroy(gameObject);
    }
}
