using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseAmmo
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
    }

    protected void Update()
    {
        if (Vector2.Distance(StartPos, transform.position) > Range)
        {
            Destroy(gameObject);
        }
        else
        {
            rb.velocity = transform.up * Speed;
        }
    }
}
