using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100;
    public int xpWorth = 10;

    private Vector2 target = Vector2.zero;

    public float speed = 10f;
    public float rSpeed = 10f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = PlayerMovement.pos - rb.position;
        dir.Normalize();

        float rAmount = Vector3.Cross(dir, transform.up).z;

        // Movement
        rb.velocity = transform.up * speed;

        // Rotation
        rb.angularVelocity = -rAmount * rSpeed;
    }

    // TODO: Detect when colliding with a wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hit player
        if (collision.gameObject.GetComponent<PlayerMovement>())
            Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        healthPoints -= dmg;
        if (healthPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // TODO: Give xp
        Destroy(gameObject);
    }
}
