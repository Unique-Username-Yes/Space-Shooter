using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerBrain : BaseBrain
{
    public float rangeToFlee = 5.0f;
    public float strafeMult = .5f;

    private float rVelocity;
    private Vector2 mVelocity;

    private void Update()
    {
        Vector2 dir = PlayerMovement.pos - rb.position;
        float rAmount = Vector3.Cross(dir, transform.up).z;
        rVelocity = -rAmount * ship.stats.RotationSpeed;

        if (IsRanged)
        {
            float dist = Vector2.Distance(PlayerMovement.pos, rb.position);

            if (dist < rangeToFlee)
            {
                // Flee
                mVelocity = (transform.up * -1.0f) * ship.stats.MovementSpeed;
            }
            else if (dist < ship.stats.Range)
            {
                // Strafe
                mVelocity = (transform.right + (transform.up * 0.01f)) * ship.stats.MovementSpeed * strafeMult;

                // Shoot only when in range
                ship.Shoot();
            }
            else
            {
                // Move to target
                mVelocity = transform.up * ship.stats.MovementSpeed;
            }
        }
        else
        {
            mVelocity = transform.up * ship.stats.MovementSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.AddTorque(rVelocity);
        rb.AddForce(mVelocity);
    }
}
