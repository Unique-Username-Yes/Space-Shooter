using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerBrain : MonoBehaviour
{
    public float progressionMultiplier;

    public float speed;
    public float stSpeed;
    public float rSpeed;
    public float range;
    public float rangeToFlee;

    public GameObject bulletP;
    float timeToFire;
    Transform firePoint;
    public float fireRate;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No StalkerBrain body found");

        firePoint = transform.Find("FirePoint");
        if (!firePoint)
            Debug.LogError("No Firepoint in staler found");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = PlayerMovement.pos - rb.position;
        dir.Normalize();

        float rAmount = Vector3.Cross(dir, transform.up).z;

        // Rotation
        rb.angularVelocity = -rAmount * rSpeed;


        float dist = Vector2.Distance(PlayerMovement.pos, rb.position);

        Vector2 force;
        if (dist < rangeToFlee)
        {
            // Flee
            force = (transform.up * -1.0f) * speed;
        }
        else if (dist < range)
        {
            // Strafe
            force = (transform.right+ (transform.up * 0.01f)) * stSpeed;

        }
        else
        {
            // Move to target
            force = transform.up  * speed;
        }

        rb.AddForce(force, ForceMode2D.Force);

        rb.velocity = Vector2.zero;
        //rb.MovePosition(force);

        //force -= rb.position;

        Shoot();
    }
    

    private void Shoot()
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;

            GameObject bullet = Instantiate(bulletP, firePoint.position, firePoint.rotation);
        }
    }
}
