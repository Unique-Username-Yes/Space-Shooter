using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public float bulletRange = 10.0f;
    public int bulletDamage = 10;
    public bool isEnemyBullet = false;

    private float distTraveled = 0.0f;
    private Vector2 initialPos;
    private Vector2 currentPos;
    private Rigidbody2D rb;

    private void Awake()
    {
        // Position of bullet
        initialPos = transform.position;
        currentPos = initialPos;

        // Bullet body
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No bullet body found");

        // TODO: play around with torque

        // Bullet moves forward using physics
        
    }

    private void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void Update()
    {
        // Update currentPos
        currentPos = transform.position;
        distTraveled = ((currentPos.x - initialPos.x) * (currentPos.x - initialPos.x)) 
            + ((currentPos.y - initialPos.y) * (currentPos.y - initialPos.y));
        if (distTraveled >= bulletRange * bulletRange)
        {
            // Bullet range reached
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isEnemyBullet)
        {
            // Bullet belongs to enemy - Deal damage only to player ship
            PlayerShip pShip = collision.GetComponent<PlayerShip>();
            if (pShip)
            {
                pShip.TakeDamage(bulletDamage);
                Remove(gameObject);
            }
        }
        else
        {
            // Bullet belongs to player - Deal damage only to enemy ships
            EnemyShip eShip = collision.GetComponent<EnemyShip>();
            if (eShip)
            {
                eShip.TakeDamage(bulletDamage);
                Remove(gameObject);
            }
        }
    }

    private void Remove(GameObject obj)
    {
        Destroy(obj);
    }
}
